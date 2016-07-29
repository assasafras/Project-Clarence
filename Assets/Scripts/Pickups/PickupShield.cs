using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.Pickups
{
    public class PickupShield : APickup
    {
        public override void Collect()
        {
            var player = BasicBitchPlayer.current;
            player.Shield.Activate();
            this.gameObject.SetActive(false);
        }
    } 
}
