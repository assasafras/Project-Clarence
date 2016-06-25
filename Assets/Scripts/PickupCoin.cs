using UnityEngine;
using System.Collections;

public class PickupCoin : MonoBehaviour// : MovingPart
{
    void Update()
    {
        if (!GameState.IsPaused)
        {
            this.transform.Rotate(0.5f, 0, 0); 
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Coin Pickup: Collided with player");
            var player = BasicBitchPlayer.current;
            player.coinsCollected += 1;
            var mp = this.transform.parent.GetComponent<MovingPart>();
            mp.SetBack();
        }
    }
}
