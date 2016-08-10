using UnityEngine;
using System.Collections;
using Assets.Scripts.Enums;
using Assets.Scripts.PlayerScripts;

public class ButtonRotateDown : MonoBehaviour
{
    public void OnClick()
    {
        Player.Current.Turn(Direction.RIGHT);
    }
}
