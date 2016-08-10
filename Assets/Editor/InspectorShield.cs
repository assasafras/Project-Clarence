using UnityEditor;

[CustomEditor(typeof(Shield))]
public class InspectorShield : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        var tar = (Shield) target;
        int previousRemaining = tar.Remaining;
        int previousTotal = tar.Total;

        tar.Total = EditorGUILayout.IntField("Total:", tar.Total);
        tar.Remaining = EditorGUILayout.IntField("Remaining:", tar.Remaining);

        if (tar.Total != previousTotal || tar.Remaining != previousRemaining)
        {
            EditorUtility.SetDirty(target);
        }
    }
}