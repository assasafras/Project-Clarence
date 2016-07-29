using Assets.Editor;
using Assets.Scripts.LevelDesign;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Chunk))]
public class InspectorChunk : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var tar = (Chunk) target;
        if (GUILayout.Button("Clear"))
        {
            tar.Pieces.Clear();
        }
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add New Piece"))
        {
            var p = CreatePiece.Create();
            tar.Pieces.Add(p);
        }
        if (GUILayout.Button("Add Empty Piece"))
        {
            tar.Pieces.Add(null);
        }
        EditorGUILayout.EndHorizontal();
        if (GUILayout.Button("Load Chunk into Scene"))
        {
            tar.LoadAllPiecesIntoScene();
        }
        for (var i = 0; i < tar.Pieces.Count; i++)
        {
            var name = "Null";

            if(tar.Pieces[i] != null)
                name = tar.Pieces[i].name;
            EditorGUILayout.BeginHorizontal();
            tar.Pieces[i] = (Piece)EditorGUILayout.ObjectField(name + ": ", (tar.Pieces[i] != null) ? tar.Pieces[i] : null, typeof(Piece), false);
            if (GUILayout.Button("Remove", GUILayout.MaxWidth(80f)))
            {
                // Remove the piece and then reduce the index we're looking at.
                tar.Pieces.RemoveAt(i--);
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Separator();
        }
    }
}
