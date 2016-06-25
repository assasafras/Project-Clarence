using Assets.Scripts.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class SecondaryWeapon : Weapon
    {
        public CustomAttribute AmmoMax;
        public int AmmoRemaining { get; set; }

    }
}
