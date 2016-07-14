using Assets.Scripts.Pickups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Events
{
    public class PlayerCollectedPickupEventArgs : EventArgs
    {
        public PlayerCollectedPickupEventArgs(APickup pickup)
        {
            p = pickup;
        }
        private APickup p;
        public APickup Pickup { get { return Pickup; } }
    }
}
