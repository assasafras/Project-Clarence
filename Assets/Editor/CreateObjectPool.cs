using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public class CreateObjectPool
    {
        public ObjectPool Create()
        {
            ObjectPool asset = ScriptableObject.CreateInstance<ObjectPool>();

            AssetDatabase.CreateAsset(asset, "Assets/ObjectPool.asset");
            AssetDatabase.SaveAssets();
            return asset;
        }
    }
}
