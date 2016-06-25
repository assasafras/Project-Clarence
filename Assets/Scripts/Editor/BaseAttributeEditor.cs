using UnityEngine;
using System.Collections;
using UnityEditor;

public class BaseAttributeEditor : Editor
{
    SerializedProperty baseValue, baseMultiplier;

    void OnEnable()
    {
        baseValue = serializedObject.FindProperty("baseValue");
        baseMultiplier = serializedObject.FindProperty("baseMultiplier");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
