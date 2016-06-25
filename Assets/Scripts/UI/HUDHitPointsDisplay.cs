﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[ExecuteInEditMode]
public class HUDHitPointsDisplay : HUDCustomBar
{
    protected override void Instatiate()
    {
        if (BasicBitchPlayer.current != null)
            totalElements = BasicBitchPlayer.current.HitPointsTotal;
        else
            totalElements = proxyTotalElements;
    }
    protected override void Update()
    {
        base.Update();

        foreach (var img in fillImages)
        {
            img.SetActive(false);
        }

        var amount = proxyTotalElements;

        if (BasicBitchPlayer.current != null)
            amount = BasicBitchPlayer.current.HP.Remaining;

        for (int i = 0; i < amount; i++)
        {
            fillImages[i].SetActive(true);
        }
    }
}