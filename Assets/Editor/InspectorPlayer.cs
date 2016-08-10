using UnityEngine;
using UnityEditor;
using Assets.Scripts.PlayerScripts;

[CustomEditor(typeof(Player))]
public class InspectorPlayer : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var tar = (Player) target;
    }
}