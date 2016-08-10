using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Bullet : MonoBehaviour
    {
        public int Damage { get; set; }
        public List<string> Effects { get; set; }

        public List<string> tagsToDamage;

        public float lifeTime;

        public void Update()
        {
            if (!GameState.IsPaused)
            {
                lifeTime -= Time.deltaTime;
                if (lifeTime <= 0)
                {
                    Destroy();
                }
            }
        }

        public void OnCollisionEnter(Collision collision)
        {
            foreach (var tag in tagsToDamage)
            {
                // "Destroy" this bullet.
                if (collision.gameObject.tag == tag)
                {
                    Destroy();
                }
            }
        }

        private void Destroy()
        {
            Debug.Log("TODO: Have bullet deal damage!");
            // Remove any velocity from the rigidbody.
            var body = GetComponent<Rigidbody>();
            body.velocity = Vector3.zero;
            body.ResetInertiaTensor();
            gameObject.SetActive(false);
        }
    }
}
