using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class Noise : MonoBehaviour
    {
        public int amount;
        void Update()
        {
            if (!GameState.IsPaused)
            {
                // Rest local position and rotation.
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;

                // Add Positional Noise.
                AddPositionalNoise(); 
            }
        }
        void AddPositionalNoise()
        {
            // reset position to start position, this allows us to not shift the player off it's start point 
            // (e.g. if the x axis had larger -ve numbers added to it more often that +ve then it would move the player).
            float amt = amount / 10000f;
            float x = Random.Range(-amt, amt);
            float y = Random.Range(-amt, amt);
            float z = Random.Range(-amt, amt);
            transform.Translate(x, y, z);
        }
    }
}
