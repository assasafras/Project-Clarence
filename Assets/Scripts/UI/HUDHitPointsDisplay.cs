using UnityEngine;
using System;
using Assets.Scripts.PlayerScripts;

[ExecuteInEditMode]
public class HUDHitPointsDisplay : HUDCustomBar
{
    protected override void Instatiate()
    {
        totalElements = target.GetComponent<HitPoints>().Total;
    }

    protected override void Update()
    {
        if (totalElements != target.GetComponent<HitPoints>().Total)
            Recreate();

        base.Update();
        foreach (var image in fillImages)
        {
            image.SetActive(false);
        }

        var noOfElements = target.GetComponent<HitPoints>().Remaining;

        for (int i = 0; i < noOfElements; i++)
        {
            fillImages[i].SetActive(true);
        }
    }
}

