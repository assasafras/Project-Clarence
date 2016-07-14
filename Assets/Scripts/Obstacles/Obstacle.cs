using Assets.Scripts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Obstacles
{
    public class Obstacle : MovingPart
    {

        public bool canCollide;
        public bool killOnCollide;
        public int damage;
    }
}