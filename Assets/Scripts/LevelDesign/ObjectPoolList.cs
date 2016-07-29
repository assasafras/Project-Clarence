using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.LevelDesign
{
    [Serializable]
    public class ObjectPoolList : ScriptableObject
    {
        public List<ObjectPool> ObjectPools;
        public static float FarthestX(ObjectPoolList pooler)
        {
            return pooler.ObjectPools.Min(pool => pool.FarthestX());
        }
        public void Initialize()
        {

        }
        public void Add()
        {
            ObjectPool asset = ScriptableObject.CreateInstance<ObjectPool>();

            AssetDatabase.CreateAsset(asset, "Assets/ObjectPool.asset");
            AssetDatabase.SaveAssets();
            ObjectPools.Add(asset);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">The name of the object that is being pooled by the ObjectPool.</param>
        /// <returns>The first ObjectPool with a name taht matches the name to search for. 
        /// If no match is found then returrns null.</returns>
        public ObjectPool GetPoolByName(string name)
        {
            foreach (var pool in ObjectPools)
            {
                if (pool.objectToPool.name == name)
                {
                    return pool;
                }
            }
            return null;
        }
    }
}
