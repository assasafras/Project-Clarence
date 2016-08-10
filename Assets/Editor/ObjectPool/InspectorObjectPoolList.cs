using Assets.Scripts.LevelDesign;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObjectPoolList))]
class InspectorObjectPoolList : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ObjectPoolList myObjectPoolList = (ObjectPoolList)target;

        if (GUILayout.Button("Add"))
        {
            myObjectPoolList.Add();
            EditorUtility.SetDirty(target);
        }
    }
}
