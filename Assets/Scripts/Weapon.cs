using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Weapon : ScriptableObject
    {
        public int damage;
        public float fireRate;
    }
}
