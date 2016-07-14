using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Pickups
{
    public abstract class APickup : MonoBehaviour
    {
        public abstract void Collect();
    }
}
