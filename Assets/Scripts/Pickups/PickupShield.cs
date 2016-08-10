using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts.Enums;

namespace Assets.Scripts.Pickups
{
    public class PickupShield : APickup
    {
        public override void Collect()
        {
            Debug.Log("Not currently implemented...");
            //var player = PlayerStats.current;
            //player.Shield.Activate();
            gameObject.SetActive(false);
        }
    } 
}
