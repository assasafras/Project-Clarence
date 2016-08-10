using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.LevelDesign
{
    [Serializable]
    public class Piece : ScriptableObject
    {
        [SerializeField, HideInInspector]
        private UnityEngine.Object prefab;
        public UnityEngine.Object Prefab
        {
            get { return prefab; }
            set
            {
                if (prefab != value)
                {
                    prefab = value;
                }

            }
        }

        [SerializeField, HideInInspector]
        private string parentName;
        public string ParentName
        {
            get { return parentName; }
            set
            {
                Debug.Log("Piece.ParentName = " + (value ?? "null"));
                if (parentName != value || Parent == null)
                {
                    if (bubble) // Call did not come from Parent's set method.
                    {
                        // Nope came from outside...
                        // Find the object with the given name in the scene.
                        if (FindAndSetParent(value))
                        {
                            // Successfully set the parent, so we can the serializable field.
                            parentName = value;
                            Save();
                        }
                    }
                    else // Call came from the Parent's set method.
                    {
                        // Just set the serializable field, the value passed through should be sane.
                        parentName = value;
                        Save();
                    }
                }
            }
        }

        private bool FindAndSetParent(string value)
        {
            bool success;
            Debug.Log("FindAndSetParent(\"" + value + "\") called.");
            var p = GameObject.Find(value);

            if (p != null) // found a valid reference.
            {
                // Turn off bubbling so setting the parent doesn't set the parent name.
                bubble = false;
                // Assign the parent object so it can be viewed in the inspector.
                Parent = p;
                // Turn bubbling back on.
                bubble = true;

                success = true;
            }
            else
            {
                success = false;
                Debug.Log("There is no object in the scene with the name \"" + value + "\"!");
            }
            return success;
        }

        bool bubble = true;
        private GameObject parent;
        public GameObject Parent
        {
            get { return parent; }
            set
            {
                var v = "null";
                if (value != null)
                    v = value.ToString();
                Debug.Log("Piece.Parent = " + v);
                if (parent != value)
                {
                    parent = value;
                    Save();
                    if (bubble) // bubble tells us if the call to change came from ParentName's set method.
                    {
                        bubble = false;
                        // Pass across the object's name, if it's null then pass through an empty string.
                        string n;
                        if (parent == null)
                            n = "";
                        else
                            n = parent.name;
                        ParentName = n;
                    }
                    bubble = true; 
                }
            }
        }

        [SerializeField, HideInInspector]
        private List<PieceTransform> transforms;
        public List<PieceTransform> Transforms
        {
            get { return transforms; }
            set
            {
                if (transforms != value)
                {
                    transforms = value;
                }
            }
        }

        void OnEnable()
        {
            if (Transforms == null)
                Transforms = new List<PieceTransform>();
            Debug.Log("SerializableTest(" + this.name + ").OnEnable - Transforms.Count: " + Transforms.Count);
            Debug.Log("SerializableTest(" + this.name + ").OnEnable - (Field) transforms.Count: " + transforms.Count);
            Debug.Log("SerializableTest(" + this.name + ").OnEnable - Prefab: " + Prefab);
            Debug.Log("SerializableTest(" + this.name + ").OnEnable - (Field) prefab: " + prefab);

            Debug.Log("SerializableTest(" + this.name + ").OnEnable - parentName: " + parentName ?? "null");
            if (parentName != null && parentName != "")
            {
                // Restore the reference (as it cannot be serialized), if it still exists...
                FindAndSetParent(parentName);
            }
        }

        public void PopulateFromScene()
        {
            var allSceneObjects = GameObject.FindObjectsOfType<GameObject>();
            foreach (var go in allSceneObjects)
            {
                if (PrefabUtility.GetPrefabParent(go) == this.Prefab)
                {
                    Transforms.Add(new PieceTransform(go));
                }
            }
            Save();
        }

        private void Save()
        {
            AssetDatabase.Refresh();
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
            Debug.Log("Saved AssetDatabase");
        }

        /// <summary>
        /// Removes all GameObjects within the current scene which are an instance of
        /// this Piece's prefab object.
        /// </summary>
        public void ClearScene()
        {
            if (Parent != null)
            {
                var allSceneObjects = GameObject.FindObjectsOfType<GameObject>();
                foreach (var go in allSceneObjects)
                {
                    if (PrefabUtility.GetPrefabParent(go) == this.Prefab)
                    {
                        DestroyImmediate(go);
                    }
                }
            }
            else
            {
                throw new NullReferenceException("Parent is null, please specify one!");
            }
            Save();
        }
        /// <summary>
        /// Loads the entire Piece into the Scene, all objects are parented to the <see cref="Parent"/> gameobject.
        /// </summary>
        public void LoadIntoScene()
        {
            if (Parent != null)
            {
                foreach (var t in Transforms)
                {
                    var go = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
                    go.transform.SetParent(Parent.transform);
                    go.transform.localPosition = t.Position;
                    go.transform.localRotation = t.Rotation;
                    go.transform.localScale = t.Scale;
                } 
            }
            else
            {
                throw new NullReferenceException("Parent is null, please specify one!");
            }
            Save();
        }
    }
}
