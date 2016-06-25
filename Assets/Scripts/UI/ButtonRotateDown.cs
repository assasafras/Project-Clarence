using UnityEngine;
using System.Collections;

public class ButtonRotateDown : MonoBehaviour
{
    public void OnClick()
    {
        World.current.RotateDown();
    }
}
