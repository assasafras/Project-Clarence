using Assets.Scripts.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class AComponent : MonoBehaviour
    {
        public float MoveSpeedBonus;
        public float TurnSpeedBonus;
        public float HitPointsTotalBonus;
        public float ShieldTotalBonus;
        public float ShieldDurationBonus;
        public float PrimaryDamageBonus;
        public float PrimaryProjectileSpeedBonus;
        public float PrimaryFireRateBonus;
        public float PrimaryReloadSpeedBonus;
        public float SecondaryDamageBonus;
        public float SecondaryProjectileSpeedBonus;
        public float SecondaryFireRateBonus;
        public float SecondaryReloadSpeedBonus;
        public float SecondaryAmmoMaxBonus;

        private RawBonus _MoveSpeedBonus;
        private RawBonus _TurnSpeedBonus;
        private RawBonus _HitPointsTotalBonus;
        private RawBonus _ShieldTotalBonus;
        private RawBonus _ShieldDurationBonus;
        private RawBonus _PrimaryDamageBonus;
        private RawBonus _PrimaryProjectileSpeedBonus;
        private RawBonus _PrimaryFireRateBonus;
        private RawBonus _PrimaryReloadSpeedBonus;
        private RawBonus _SecondaryDamageBonus;
        private RawBonus _SecondaryProjectileSpeedBonus;
        private RawBonus _SecondaryFireRateBonus;
        private RawBonus _SecondaryReloadSpeedBonus;
        private RawBonus _SecondaryAmmoMaxBonus;

        protected Player player;
        void Awake()
        {
            player = GameObject.Find("Player").GetComponent<Player>();

            _MoveSpeedBonus                 = new RawBonus(MoveSpeedBonus);
            _TurnSpeedBonus                 = new RawBonus(TurnSpeedBonus);
            _HitPointsTotalBonus            = new RawBonus(HitPointsTotalBonus);
            _ShieldTotalBonus               = new RawBonus(ShieldTotalBonus);
            _ShieldDurationBonus            = new RawBonus(ShieldDurationBonus);
            _PrimaryDamageBonus             = new RawBonus(PrimaryDamageBonus);
            _PrimaryProjectileSpeedBonus    = new RawBonus(PrimaryProjectileSpeedBonus);
            _PrimaryFireRateBonus           = new RawBonus(PrimaryFireRateBonus);
            _PrimaryReloadSpeedBonus        = new RawBonus(PrimaryReloadSpeedBonus);
            _SecondaryDamageBonus           = new RawBonus(SecondaryDamageBonus);
            _SecondaryProjectileSpeedBonus  = new RawBonus(SecondaryProjectileSpeedBonus);
            _SecondaryFireRateBonus         = new RawBonus(SecondaryFireRateBonus);
            _SecondaryReloadSpeedBonus      = new RawBonus(SecondaryReloadSpeedBonus);
            _SecondaryAmmoMaxBonus          = new RawBonus(SecondaryAmmoMaxBonus);
            
        }
        /// <summary>
        /// Automatically called as part of on OnEnable.
        /// </summary>
        protected void AddAttributesToPlayer()
        {
            player.AddBonus(Player.AttributeType.MoveSpeed, _MoveSpeedBonus);
            player.AddBonus(Player.AttributeType.TurnSpeed, _TurnSpeedBonus);
            player.AddBonus(Player.AttributeType.HitPointsTotal, _HitPointsTotalBonus);
            player.AddBonus(Player.AttributeType.ShieldTotal, _ShieldTotalBonus);
            player.AddBonus(Player.AttributeType.ShieldDuration, _ShieldDurationBonus);
            player.AddBonus(Player.AttributeType.PrimaryDamage, _PrimaryDamageBonus);
            player.AddBonus(Player.AttributeType.PrimaryProjectileSpeed, _PrimaryProjectileSpeedBonus);
            player.AddBonus(Player.AttributeType.PrimaryFireRate, _PrimaryFireRateBonus);
            player.AddBonus(Player.AttributeType.PrimaryReloadSpeed, _PrimaryReloadSpeedBonus);
            player.AddBonus(Player.AttributeType.SecondaryDamage, _SecondaryDamageBonus);
            player.AddBonus(Player.AttributeType.SecondaryProjectileSpeed, _SecondaryProjectileSpeedBonus);
            player.AddBonus(Player.AttributeType.SecondaryFireRate, _SecondaryFireRateBonus);
            player.AddBonus(Player.AttributeType.SecondaryReloadSpeed, _SecondaryReloadSpeedBonus);
            player.AddBonus(Player.AttributeType.SecondaryAmmoMax, _SecondaryAmmoMaxBonus);
        }
        /// <summary>
        /// Automatically called as part of on OnDisable.
        /// </summary>
        protected void RemoveAttributesFromPlayer()
        {
            player.RemoveBonus(Player.AttributeType.MoveSpeed, _MoveSpeedBonus);
            player.RemoveBonus(Player.AttributeType.TurnSpeed, _TurnSpeedBonus);
            player.RemoveBonus(Player.AttributeType.HitPointsTotal, _HitPointsTotalBonus);
            player.RemoveBonus(Player.AttributeType.ShieldTotal, _ShieldTotalBonus);
            player.RemoveBonus(Player.AttributeType.ShieldDuration, _ShieldDurationBonus);
            player.RemoveBonus(Player.AttributeType.PrimaryDamage, _PrimaryDamageBonus);
            player.RemoveBonus(Player.AttributeType.PrimaryProjectileSpeed, _PrimaryProjectileSpeedBonus);
            player.RemoveBonus(Player.AttributeType.PrimaryFireRate, _PrimaryFireRateBonus);
            player.RemoveBonus(Player.AttributeType.PrimaryReloadSpeed, _PrimaryReloadSpeedBonus);
            player.RemoveBonus(Player.AttributeType.SecondaryDamage, _SecondaryDamageBonus);
            player.RemoveBonus(Player.AttributeType.SecondaryProjectileSpeed, _SecondaryProjectileSpeedBonus);
            player.RemoveBonus(Player.AttributeType.SecondaryFireRate, _SecondaryFireRateBonus);
            player.RemoveBonus(Player.AttributeType.SecondaryReloadSpeed, _SecondaryReloadSpeedBonus);
            player.RemoveBonus(Player.AttributeType.SecondaryAmmoMax, _SecondaryAmmoMaxBonus);
        }
        void OnEnable()
        {
            AddAttributesToPlayer();
        }
        void OnDisable()
        {
            RemoveAttributesFromPlayer();
        }

        void OnValidate()
        {

        }
    }
}
