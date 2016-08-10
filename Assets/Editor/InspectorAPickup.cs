using UnityEditor;
using Assets.Scripts.Pickups;
using Assets.Scripts.Enums;

[CustomEditor(typeof(APickup))]
public class InspectorAPickup : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var tar = (APickup)target;

        tar.type = (PickupType) EditorGUILayout.EnumPopup("Pickup Type: ", tar.type);
    }
}
