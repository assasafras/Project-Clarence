using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Pickups
{
    public abstract class APickup : MonoBehaviour
    {

        public PickupType type;

        public abstract void Collect();
    }
}
