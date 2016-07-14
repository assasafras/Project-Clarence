using System;
using Assets.Scripts.Obstacles;
namespace Assets.Scripts.Events
{
    /// <summary>
    /// Event arguments for a collision between the player and a Obstacle.
    /// </summary>
    public class PlayerCollisionEventArgs : EventArgs
    {
        public PlayerCollisionEventArgs(Obstacle obstacle)
        {
            obs = obstacle;
        }

        private Obstacle obs;

        public Obstacle Obs { get { return obs; } }
    }
}
