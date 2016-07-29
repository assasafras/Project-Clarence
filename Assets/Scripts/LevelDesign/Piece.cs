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
        private GameObject parent;
        public GameObject Parent
        {
            get { return parent; }
            set
            {
                if (parent != value)
                {
                    parent = value;
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
        }
    }
}
