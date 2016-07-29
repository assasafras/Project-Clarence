using Assets.Scripts.LevelDesign;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public class CreateChunk
    {
        [MenuItem("Assets/Create/Chunk")]
        public static Chunk Create()
        {
            return Create(null);
        }
        public static Chunk Create(string name)
        {
            Debug.Log("CreateChunk.Create Called!");
            Chunk asset = ScriptableObject.CreateInstance<Chunk>();
            //asset.Initialize();
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
            return asset;
        }
    }
}
