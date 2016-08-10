using Assets.Scripts.Events;
using System;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    class PausableRigidBody : APausable<Rigidbody>
    {
        private Vector3 previousVelocity;

        public override void PausedHandler(PausedEventArgs e)
        {
            if (e.IsPaused)
            {
                previousVelocity = component.velocity;
                component.velocity = Vector3.zero;
            }
            else
                component.velocity = previousVelocity;

        }
    }
}
