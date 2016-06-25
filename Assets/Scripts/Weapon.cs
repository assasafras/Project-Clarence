using Assets.Scripts.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using at = Player.AttributeType;

namespace Assets.Scripts
{
    public class Weapon : AComponent
    {
        private float fireCooldown;
        public GameObject Projectile { get; set; }

        private bool _canFire;
        public bool CanFire {
            get { return _canFire; }
            set {
                _canFire = value;
                if (!_canFire)
                    fireCooldown = FireRate;
            }
        }

        // Weapon Attributes
        public CustomAttribute Damage = new CustomAttribute();
        public CustomAttribute ProjectileSpeed = new CustomAttribute();
        public CustomAttribute ReloadSpeed = new CustomAttribute();
        public CustomAttribute FireRate = new CustomAttribute();
        public CustomAttribute ClipSize = new CustomAttribute();

        public bool Fire()
        {
            if (CanFire)
            {
                print("Firing!");
                CanFire = false;
                return true;
            }
            else
            {
                //print("Not Firing!");
                return false;
            }
        }

        //public RawBonus PrimaryDamageBonus = new RawBonus(1f);
        //public RawBonus PrimaryProjectileSpeedBonus = new RawBonus(1f);
        //public RawBonus PrimaryFireRateBonus = new RawBonus(1f);
        //public RawBonus PrimaryReloadSpeedBonus = new RawBonus(1f);
        //override protected void AddAttributesToPlayer()
        //{
        //    player.AddBonus(at.PrimaryDamage, PrimaryDamageBonus);
        //    player.AddBonus(at.PrimaryProjectileSpeed, PrimaryProjectileSpeedBonus);
        //    player.AddBonus(at.PrimaryProjectileSpeed, PrimaryProjectileSpeedBonus);
        //    player.AddBonus(at.PrimaryFireRate, PrimaryFireRateBonus);
        //    player.AddBonus(at.PrimaryReloadSpeed, PrimaryReloadSpeedBonus);
        //}
        //override protected void RemoveAttributesFromPlayer()
        //{
        //    player.RemoveBonus(at.PrimaryDamage, PrimaryDamageBonus);
        //    player.RemoveBonus(at.PrimaryProjectileSpeed, PrimaryProjectileSpeedBonus);
        //    player.RemoveBonus(at.PrimaryFireRate, PrimaryFireRateBonus);
        //    player.RemoveBonus(at.PrimaryReloadSpeed, PrimaryReloadSpeedBonus);
        //}

        public void Update()
        {
            if (!CanFire)
            {
                if (fireCooldown < 0)
                {
                    CanFire = true;
                }
                else
                {
                    //print("Fire Cooldown: " + fireCooldown);
                    fireCooldown -= Time.deltaTime;
                }
            }
        }

    }
}
