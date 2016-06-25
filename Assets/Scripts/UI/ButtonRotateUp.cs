using UnityEngine;
using System.Collections;

public class ButtonRotateUp : MonoBehaviour
{
    public void OnClick()
    {
        World.current.RotateUp();
    }
}
