using System;
using Assets.Scripts;
using Assets.Scripts.Attributes;
using UnityEngine;

public class Hull : AComponent
{
    public Vector3 WingOffset, WingScale, WingRotation;
    public Vector3 EngineOffset, EngineScale, EngineRotation;
    public Vector3 ShieldOffset, ShieldScale, ShieldRotation;

    //public RawBonus hpBonus = new RawBonus(1f);
    //override protected void AddAttributesToPlayer()
    //{
    //    //player.HitPointsTotal.AddRawBonus(hpBonus);
    //}

    //protected override void RemoveAttributesFromPlayer()
    //{
    //    //player.HitPointsTotal.RemoveRawBonus(hpBonus);
    //}
}