using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ObjectPool))]
public class InspectorObjectPool : Editor
{
    public override void OnInspectorGUI()
    {
        var tar = (ObjectPool) target;

        GUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Name:");
        tar.name = EditorGUILayout.TextField(tar.name);
        GUILayout.EndHorizontal();

        base.OnInspectorGUI();
    }
}
