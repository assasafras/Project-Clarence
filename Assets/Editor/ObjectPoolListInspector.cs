using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObjectPoolList))]
class ObjectPoolListInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ObjectPoolList myObjectPoolList = (ObjectPoolList)target;

        if (GUILayout.Button("Add"))
        {
            myObjectPoolList.Add();
        }
    }
}
