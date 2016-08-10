using Assets.Scripts.LevelDesign;
using Assets.Scripts.PlayerScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    /// <summary>
    /// Base class of all weapon objects.
    /// </summary>
    public class BaseWeapon : MonoBehaviour
    {
        public ObjectPool pool;
        public List<Transform> BulletSpawnPoints;
        /// <summary>
        /// Number of bullets fired per second.
        /// </summary>
        public int FireRate { get { return fireRate; } set { fireRate = value; } }
        [SerializeField]
        private int fireRate;

        /// <summary>
        /// Damage dealt per bullet.
        /// </summary>
        public int BulletDamage { get { return damage; } set { damage = value; } }
        [SerializeField]
        private int damage;

        /// <summary>
        /// The number of units travelled per second.
        /// </summary>
        public float BulletSpeed { get { return bulletSpeed; } set { bulletSpeed = value; } }
        [SerializeField]
        private float bulletSpeed;

        /// <summary>
        /// Effects to attach to bullets fired by this weapon.
        /// </summary>
        public List<string> BulletEffects { get { return bulletEffects; } set { bulletEffects = value; } }
        [SerializeField]
        private List<string> bulletEffects;

        /// <summary>
        /// How long (in seconds) the bullets remain alive for.
        /// </summary>
        public float BulletLifeTime { get { return bulletLifeTime; } set { bulletLifeTime = value; } }
        [SerializeField]
        private float bulletLifeTime;

        private bool canFire;
        private float fireCooldown;

        void Update()
        {
            if (!GameState.IsPaused)
            {
                if (Player.Current.isFiringPrimary)
                {
                    Fire();
                }
                if (!canFire)
                {
                    fireCooldown -= Time.deltaTime;
                    if (fireCooldown <= 0)
                    {
                        canFire = true;
                    }
                } 
            }
        }

        /// <summary>
        /// Creates a bullet instance sets properties and adds any effects. Then return the bullet reference to the caller.
        /// </summary>
        /// <returns></returns>
        public void Fire()
        {
            if (canFire)
            {
                canFire = false;
                fireCooldown = 1/Convert.ToSingle(fireRate);
                foreach (var spawn in BulletSpawnPoints)
                {
                    var bulletInstance = pool.GetObjectFromPool();

                    var bulletScript = bulletInstance.GetComponent<Bullet>();
                    bulletScript.Damage = BulletDamage;
                    bulletScript.Effects = BulletEffects;
                    bulletScript.lifeTime = BulletLifeTime;

                    bulletInstance.transform.rotation = spawn.rotation;
                    bulletInstance.transform.position = spawn.position;

                    var bulletRigidBody = bulletInstance.GetComponent<Rigidbody>();
                    bulletRigidBody.AddForce(-bulletSpeed, 0, 0);
                    //return bulletInstance;
                } 
            }
        }
    }
}
