using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ObjectPool))]
public class ObjectPoolInspector : Editor
{
    public override void OnInspectorGUI()
    {
        ObjectPool myObjectPool = (ObjectPool)target;

        GUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Name:");
        myObjectPool.name = EditorGUILayout.TextField(myObjectPool.name);
        GUILayout.EndHorizontal();

        base.OnInspectorGUI();
    }
}
