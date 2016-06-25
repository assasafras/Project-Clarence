using UnityEngine;
using System.Collections;
using System;

public class PickupShield : MovingPart
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("Shield Pickup: Collided with player");
            var player = BasicBitchPlayer.current;
            player.Shield.Activate();
        }
    }
}
