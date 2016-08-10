using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public class CreateObjectPool
    {
        [MenuItem("Assets/Create/Object Pool")]
        public ObjectPool Create()
        {
            ObjectPool asset = ScriptableObject.CreateInstance<ObjectPool>();

            AssetDatabase.CreateAsset(asset, "Assets/ScriptableObjects/ObjectPools/ObjectPool.asset");
            AssetDatabase.SaveAssets();
            return asset;
        }
    }
}
