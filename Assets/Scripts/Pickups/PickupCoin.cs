using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.Pickups
{
    public class PickupCoin : APickup
    {
        void Update()
        {
            if (!GameState.IsPaused)
            {
                this.transform.Rotate(0.5f, 0, 0);
            }
        }
        public override void Collect()
        {
            //var player = PlayerStats.current;
            LevelState.coinsCollected += 1;
            this.gameObject.SetActive(false);
            //var mp = this.transform.parent.GetComponent<MovingPart>();
            //mp.SetBack();
        }
    } 
}
