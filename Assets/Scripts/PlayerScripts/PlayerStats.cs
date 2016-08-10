using UnityEngine;
using System;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Weapons;

namespace Assets.Scripts.PlayerScripts
{
    public partial class Player
    {
        public bool isFiringPrimary;
        public bool isFiringSecondary;

        [Range(0, 100)]
        public float moveSpeed;
        public float MoveSpeed { get { return moveSpeed / 10f; } set { moveSpeed = (value * 10f); } }
        [Range(0f, 1000f)]
        public float TurnSpeed;

        public bool godMode = false;
        
        public Shield Shield { get; private set; }
        public HitPoints HP { get; private set; }

        public BaseWeapon PrimaryWeapon { get; private set; }
        //public SecondaryWeapon SecondaryWeapon;

        public void TakeDamage(int damage, object source)
        {
            // Only deal damage to the player if damage is 1 or more. Negative numbers aren't sensible.
            if (damage > 0)
            {
                // Let everyone know we're taking damage.
                OnTakeDamage(damage, source);

                var damageRemainingToBeDealt = damage;
                if (Shield != null && Shield.Active)
                {
                    // Let everyone know we're taking Shield damage.
                    OnTakeShieldDamage(damageRemainingToBeDealt, source);
                    // Is the damage to be dealt greater than the shield's remaining Hit Points?
                    damageRemainingToBeDealt -= Shield.Remaining;
                    // Deal damage to the Shield.
                    Shield.Remaining -= damage;
                    // If shield was destroyed raise an event.
                    if (!Shield.Active)
                        OnShieldDestroyed(source);
                }
                // Is there any damage left to be dealt to Hit Points?
                if (damageRemainingToBeDealt > 0)
                {
                    // Let everyone know we're taking Hit Point damage.
                    OnTakeHPDamage(damageRemainingToBeDealt, source);
                    // Deal damage to the Player's Hit Points.
                    HP.Remaining -= damageRemainingToBeDealt;
                    // Is the player still alive after taking the damage?
                    if (!HP.Alive)
                        Kill(source);
                } 
            }
        }

        private void Kill(object source)
        {
            //Raise Killed Event for anyone listening.
            OnKilled(source);

            // Then end the game.
            GameState.EndGame();
        }
    }
}