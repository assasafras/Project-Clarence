using Assets.Scripts.LevelDesign;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public class CreatePiece
    {
        [MenuItem("Assets/Create/Piece")]
        public static Piece Create()
        {
            string name = null;
            Debug.Log("Piece.Create Called!");
            var asset = ScriptableObject.CreateInstance<Piece>();

            var path = "";
            var suffix = ".asset";
            if (name != null)
            {
                path = "Assets/ScriptableObjects/Chunks/Pieces/" + name + suffix;
            }
            else
            {
                path = "Assets/ScriptableObjects/Chunks/Pieces/Piece";

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

