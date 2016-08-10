using UnityEngine;
using System;
using Assets.Scripts.PlayerScripts;

[ExecuteInEditMode]
public class HUDShieldDisplay : HUDCustomBar
{

    protected override void Instatiate()
    {
        totalElements = target.GetComponent<Shield>().Total;
    }
    protected override void Update()
    {
        if (totalElements != target.GetComponent<Shield>().Total)
            Recreate();

        base.Update();
        foreach (var image in fillImages)
        {
            image.SetActive(false);
        }

        var noOfElements = target.GetComponent<Shield>().Remaining;

        for (int i = 0; i < noOfElements; i++)
        {
            fillImages[i].SetActive(true);
        }
    }
}
