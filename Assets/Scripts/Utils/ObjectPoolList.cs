using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class ObjectPoolList : ScriptableObject
    {
        public List<ObjectPool> ObjectPools;
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
    }
}
