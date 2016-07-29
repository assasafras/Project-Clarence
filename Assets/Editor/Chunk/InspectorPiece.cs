using Assets.Scripts.LevelDesign;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Piece))]
public class InspectorPiece : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var tar = (Piece)target;

        EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Load Transforms from scene"))
            {
                tar.Transforms.Clear();
                tar.PopulateFromScene();
            }
            if (GUILayout.Button("Clear"))
            {
                tar.Transforms.Clear();
            }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Load Into Scene"))
            {
                tar.ClearScene();
                tar.LoadIntoScene();
            }
        EditorGUILayout.EndHorizontal();

        tar.Parent = (GameObject) EditorGUILayout.ObjectField("Parent: ", tar.Parent, typeof(GameObject), true);
        if (tar.Parent == null)
            EditorGUILayout.LabelField("You must specify a Parent GameObject from the Scene!");
        tar.Prefab = EditorGUILayout.ObjectField("Prefab: ", tar.Prefab, typeof(GameObject), false);

        if (tar.Prefab == null)
            EditorGUILayout.LabelField("You must specify a Prefab GameObject from Assets!");

        EditorGUILayout.IntField("No. of Transforms: ", tar.Transforms.Count);

        if (tar.Prefab != null)
        {
            DrawTransforms(tar);
        }
        GUILayout.HorizontalSlider(0, 0, 0);
    }

    private static void DrawTransforms(Piece tar)
    {
        // Grab a list of Transforms.
        foreach (var t in tar.Transforms)
        {
            EditorGUILayout.Vector3Field("Position: ", t.Position);
            EditorGUILayout.Vector3Field("Rotation: ", t.EulerAngles);
            EditorGUILayout.Vector3Field("Scale: ", t.Scale);
            EditorGUILayout.Separator();

        }
    }
}
