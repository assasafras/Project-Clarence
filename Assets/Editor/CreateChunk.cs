using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public class CreateChunk
    {
        [MenuItem("Assets/Create/Chunk")]
        public static Chunk Create(string name = null)
        {
            Chunk asset = ScriptableObject.CreateInstance<Chunk>();
            asset.Initialize();
            var path = "";
            var suffix = ".asset";
            if (name != null)
            {
                path = "Assets/ScriptableObjects/Chunks/" + name + suffix;
            }
            else
            {
                path = "Assets/ScriptableObjects/Chunks/Chunk";
                
                var workingPath = path + suffix;
                var i = 1;
                var a = AssetDatabase.AssetPathToGUID(workingPath);
                // Determine if there already an asset with the same name in the asset database.
                while (AssetDatabase.AssetPathToGUID(workingPath) != "")
                {
                    // If so then change the name and check again.
                    workingPath = path + i++ + suffix;
                    if (i > 10000) break;
                }
                path = workingPath;
            }
            AssetDatabase.CreateAsset(asset, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            // Get the GUID of the Object pooler.
            string guidObjectPooler = AssetDatabase.FindAssets("ObjectPooler", new string[] { "Assets/ScriptableObjects" }).First();
            string pathObjectPooler = AssetDatabase.GUIDToAssetPath(guidObjectPooler);
            var objectPooler = AssetDatabase.LoadAssetAtPath<ObjectPoolList>(pathObjectPooler);
            // FInd the game objects in scene that are of the type that we are pooling.
            foreach (var pool in objectPooler.ObjectPools)
            {
                var poolPrefab = pool.PooledObjectPrefab;
                // Push all the objects of the given type into the chunk.
                foreach (var obj in GameObject.FindObjectsOfType<GameObject>())
                {
                    // We want a reference to the prefab used to create the object.
                    if (PrefabUtility.GetPrefabType(obj) == PrefabType.PrefabInstance)
                    {
                        var prefabParent = PrefabUtility.GetPrefabParent(obj);
                        if (prefabParent == poolPrefab)
                        {
                            var go = (GameObject)obj;
                            var transform = go.transform;
                            asset.AddPiece(poolPrefab as GameObject, transform);
                        }
                    }
                }
            }
            Selection.activeObject = asset;
            return asset;
        }
    }
}
