using UnityEngine;
using System.Collections;

public class Obstacle : MovingPart
{
    public int damage = 1;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Obstacle ("+this.transform.parent.name+"): Collided with player");
            var player = BasicBitchPlayer.current;
            if (!player.godMode)
                player.TakeDamage(damage);
        }
    }
}
