using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
public class HUDShieldDisplay : HUDCustomBar
{
    protected override void Instatiate()
    {
        if (BasicBitchPlayer.current != null)
            totalElements = BasicBitchPlayer.current.ShieldTotal;
        else
            totalElements = proxyTotalElements;
    }

    void Update()
    {
        foreach (var img in fillImages)
        {
            img.SetActive(false);
        }

        var amount = Convert.ToSingle(proxyTotalElements);

        if (BasicBitchPlayer.current != null)
            amount = BasicBitchPlayer.current.Shield.Remaining;

        for (int i = 0; i < amount; i++)
        {
            fillImages[i].SetActive(true);
        }
    }
}
