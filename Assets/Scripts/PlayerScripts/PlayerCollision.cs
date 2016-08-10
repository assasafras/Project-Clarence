using Assets.Scripts.Enums;
using Assets.Scripts.Events;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Obstacles;
using Assets.Scripts.Pickups;
using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public partial class Player
    {
        public delegate void PlayerCollisionHandler(object sender, PlayerCollisionEventArgs a);
        public event PlayerCollisionHandler PlayerObstacleCollision = delegate { };

        public delegate void PlayerCollectedPickupHandler(object sender, PlayerCollectedPickupEventArgs a);
        public event PlayerCollectedPickupHandler PlayerCollectedPickup = delegate { };


        protected virtual void OnCollisionEnter(Collision other)
        {
            // Raise a simple collision event.
            OnCollision(other);
            // Have we collided with an Obstacle?
            if (other.gameObject.CompareTag("Obstacle"))
            {
                CollidedWithObstacle(other);
            }
            // What about a Pickup?
            else if (other.gameObject.CompareTag("Pickup"))
            {
                CollidedWithPickUp(other);
            }
        }
        private void CollidedWithObstacle(Collision other)
        {
            Obstacle obs;
            // Find the Obstacle component on the other object (should have one if it has the tag "Obstacle").
            try
            {
                obs = other.gameObject.GetComponent<Obstacle>();
            }
            catch (Exception)
            {
                throw new Exception("Error in method " + ExceptionUtils.GetCurrentMethod() + " of " + ExceptionUtils.GetCurrentClass(this)
                    + ": Failed to find an Obstacle Script on the game object - " + ExceptionUtils.GetCurrentClass(other.gameObject));
            }
            // We have, raise an event for anyone listening!
            Debug.Log("CollidedWithObstacle - Not implemented yet...");

            // Now deal with the collision.
            if (!godMode)
            {
                if (obs.killOnCollide)
                {
                    TakeDamage(HP.Remaining, obs);
                }
                else
                {
                    TakeDamage(obs.damage, obs);
                }
            }
        }

        private void CollidedWithPickUp(Collision other)
        {
            APickup pickup;
            // Find the Obstacle component on the other object (should have one if it has the tag "Obstacle").
            try
            {
                pickup = other.gameObject.GetComponent<APickup>();
            }
            catch (Exception)
            {
                throw new Exception("Error in method " + ExceptionUtils.GetCurrentMethod() + " of " + ExceptionUtils.GetCurrentClass(this)
                    + ": Failed to find an APickup Script on the game object - " + ExceptionUtils.GetCurrentClass(other.gameObject));
            }
            // We have, raise an event for anyone listening!
            OnCollectedPickup(pickup.type);

            // Now deal with the collision.
            pickup.Collect();
        }
    }
}
