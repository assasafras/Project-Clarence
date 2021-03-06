﻿using UnityEngine;
using UnityEditor;
using Assets.Scripts.LevelDesign;

namespace Assets.Editor
{

    public class CreateObjectPoolList
    {
        [MenuItem("Assets/Create/Object Pool List")]
        public static ObjectPoolList Create()
        {
            ObjectPoolList asset = ScriptableObject.CreateInstance<ObjectPoolList>();

            AssetDatabase.CreateAsset(asset, "Assets/ScriptableObjects/ObjectPoolList.asset");
            AssetDatabase.SaveAssets();
            return asset;
        }
    }
}
