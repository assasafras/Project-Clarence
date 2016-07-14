using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    [Serializable]
    public class Chunk : ScriptableObject
    {
        private List<PieceList> _pieces;

        public List<PieceList> Pieces { get { return _pieces; } }

        public void AddPiece(UnityEngine.Object prefab, Transform transform)
        {
            var position = transform.localPosition;
            var rotation = transform.localRotation;
            var scale    = transform.localScale;

            foreach (var piece in Pieces)
            {
                if (ReferenceEquals(piece.gameObject, prefab))
                {
                    piece.Transforms.Add
                        (
                            new MyTransform
                            {
                                rotation = rotation
                                , position = position
                                , scale = scale
                            }
                        );
                    return;
                }
            }
            Pieces.Add
                (
                    new PieceList()
                        {
                            gameObject = (GameObject)prefab
                            , Transforms = new List<MyTransform>()
                            { new MyTransform { rotation = rotation, position = position, scale = scale} }
                        }
                );
        }

        /// <summary>
        /// Loads all pieces into the scene, parenting is done based on the tag of the gameObject
        /// associated with each piece. <para>Note that all objects that will share the parent of the 
        /// newly added gameobjects will have all children removed before hand.</para>
        /// <para>This is to be called during edit mode only.</para>
        /// </summary>
        public void LoadIntoScene()
        {
            // Check that the editor is in editor mode before running anything.
            if (Application.isEditor)
            {
                // Loop through each piece in the Pieces List.
                foreach (var piece in Pieces)
                {
                    // First grab the tag of the gameobject associated with the piece.
                    var tag = piece.gameObject.tag;
                    // Find the game object in the scene with the name that matches the tag, 
                    // this will be the parent of all objects with the given tag.
                    var parent = GameObject.Find(tag);
                    // Now delete all children of the parent.
                    while (parent.transform.childCount > 0)
                    {
                        var t = parent.transform.GetChild(0);
                        var go = t.gameObject;
                        DestroyImmediate(go);
                    }
                }
                // All parent objects should now be cleared of their children.
                // Next let's add our pieces of this chunk into the scene under their respective parents.

                // Loop through each piece in the Pieces List.
                foreach (var piece in Pieces)
                {
                    // First grab the tag of the gameobject associated with the piece.
                    var tag = piece.gameObject.tag;
                    // Find the game object in the scene with the name that matches the tag, 
                    // this will be the parent of all objects with the given tag.
                    var parent = GameObject.Find(tag);
                    // Now loop through each of the transforms which represent where an object should be placed.
                    var i = 0;
                    foreach (var transform in piece.Transforms)
                    {
                        var go = (GameObject)PrefabUtility.InstantiatePrefab(piece.gameObject);
                        go.name += " " + (++i).ToString();
                        // Parent the newly created gameObject to the parent object set before.
                        go.transform.SetParent(parent.transform);
                        // Set transforms of the newly created gameobject.
                        go.transform.localRotation  = transform.rotation;
                        go.transform.localPosition  = transform.position;
                        go.transform.localScale     = transform.scale;
                    }
                }
            }
            else
            {
                Debug.Log(ExceptionUtils.GetCurrentClass(this) + " " + ExceptionUtils.GetCurrentMethod() + ". Cannot be called unless Unity is in Edit Mode!");
            }
        }

        public void Initialize()
        {
            _pieces = new List<PieceList>();
        }

        [Serializable]
        public class PieceList
        {
            public GameObject gameObject { get; set; }
            public List<MyTransform> Transforms { get; set; }
            public PieceList()
            {
                Transforms = new List<MyTransform>();
            }

        }
        [Serializable]
        public class MyTransform
        {
            public Vector3 position = Vector3.zero;
            public Vector3 eulerAngles { get { return rotation.eulerAngles; } }
            public Quaternion rotation = Quaternion.identity;
            public Vector3 scale = Vector3.zero;
        }
    }
}
