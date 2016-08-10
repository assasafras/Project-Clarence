using UnityEngine;
using System.Collections;
using Assets.Scripts.PlayerScripts;
using Assets.Scripts.Enums;

public class ButtonRotateUp : MonoBehaviour
{
    public void OnClick()
    {
        Player.Current.Turn(Direction.RIGHT);
    }
}
