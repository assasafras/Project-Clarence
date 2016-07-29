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
