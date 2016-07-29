using UnityEditor;
using UnityEngine;

public class ObjectPrefabTest
{
    [MenuItem("Assets/PrefabTest")]
    public static UnityEngine.Object Create()
    {
        var instance = PrefabUtility.InstantiatePrefab(Selection.activeObject as GameObject) as GameObject;
        UnityEngine.Object prefab;
        try
        {
            //var instance = GameObject.Instantiate(obj);
            prefab = PrefabUtility.GetPrefabParent(instance);
            PrefabType a = PrefabUtility.GetPrefabType(instance);//.ToString();
            Debug.Log(instance.ToString() + " | prefab: " + prefab.ToString() + " | type: " + a);
        }
        finally
        {
            GameObject.DestroyImmediate(instance);
        }
        return prefab;
    }

    [@MenuItem("Examples/Instantiate Selected")]
    static void CreatePrefab()
    {
        var clone = PrefabUtility.InstantiatePrefab(Selection.activeObject as GameObject) as GameObject;
    }

    [@MenuItem("Examples/Instantiate Selected", true)]
    static bool ValidateCreatePrefab()
    {
        GameObject go = Selection.activeObject as GameObject;
        if (go == null)
            return false;

        return PrefabUtility.GetPrefabType(go) == PrefabType.Prefab || PrefabUtility.GetPrefabType(go) == PrefabType.ModelPrefab;
    }
}