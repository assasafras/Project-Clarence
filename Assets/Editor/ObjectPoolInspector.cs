using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ObjectPool))]
public class ObjectPoolInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ObjectPool myObjectPool = (ObjectPool)target;

        EditorGUILayout.IntField("Hello", 1);

        //foreach (var keyValuePair in myObjectPool.Elements)
        //{
        //    EditorGUI.ObjectField(new Rect(0, 0, 0, 0), keyValuePair, typeof(GameObject), true);
        //    EditorGUILayout.IntField("Hello", 1);
        //}
    }
}
