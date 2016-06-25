using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpStateButton : Button
{
    public void Update()
    {
        //A public function in the selectable class which button inherits from.
        if (IsPressed())
        {
            WhilePressed();
        }
    }

    public void WhilePressed()
    {
        World.current.RotateUp();
    }
}
