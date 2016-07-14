using Assets.Editor;
using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Chunk))]
public class ChunkInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Chunk myChunk = (Chunk)target;
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Load From Scene"))
        {
            string n = target.name;
            string path = AssetDatabase.GetAssetPath(target);
            AssetDatabase.DeleteAsset(path);
            var c = CreateChunk.Create(n);
            myChunk = c;
            Selection.activeObject = c;
        }
        if (GUILayout.Button("Load Into Scene"))
        {
            myChunk.LoadIntoScene();
        }
        GUILayout.EndHorizontal();
        foreach (var piece in myChunk.Pieces)
        {
            EditorGUI.BeginDisabledGroup(true);

                GUILayout.BeginHorizontal();

                    EditorGUILayout.PrefixLabel("Piece:");
                    EditorGUILayout.ObjectField(piece.gameObject, piece.gameObject.GetType(), false, new GUILayoutOption[] { });

                GUILayout.EndHorizontal();

                EditorGUILayout.IntField("Amount:", piece.Transforms.Count);

            EditorGUI.EndDisabledGroup();

            foreach (var t in piece.Transforms)
            {
                t.position = EditorGUILayout.Vector3Field("Position:", t.position);
                t.rotation = Quaternion.Euler(EditorGUILayout.Vector3Field("Rotation:", t.eulerAngles));
                t.scale = EditorGUILayout.Vector3Field("Scale:", t.scale);
                EditorGUILayout.Separator();
            }
            GUILayout.HorizontalSlider(0, 0, 0);
        }
    }
}
