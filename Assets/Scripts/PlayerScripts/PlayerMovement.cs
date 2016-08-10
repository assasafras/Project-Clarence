using Assets.Scripts.Enums;
using Assets.Scripts.Events;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    /// <summary>
    /// Handles movement events from a controller.
    /// </summary>
    public partial class Player
    {
        private float degreesLeftToRotate;
        private float directionMultiplier; // -1 is left, 1 is right, used to multiply degrees to rotate.
        private float previousMoveSpeed;
        private Direction currentDirection = Direction.NONE;

        public void Turn(Direction dir)
        {
            // Are we already turning in a direction?
            if (currentDirection == Direction.NONE)
            {
                // Stop this from being requested to turn.
                currentDirection = dir;

                // Raise an event for anyone listening that we are begining to turn.
                OnTurningBegin(dir);
                
                switch (dir)
                {
                    case Direction.LEFT:
                        directionMultiplier = -1;
                        break;
                    case Direction.RIGHT:
                        directionMultiplier = 1;
                        break;
                }

                // Set the number of degrees we need to rotate.
                degreesLeftToRotate = directionMultiplier * 30f;
            }
        }

        void Update()
        {
            if (!GameState.IsPaused)
            {
                // Process Movement forward.
                OnMoved(MoveSpeed * Time.deltaTime);

                var degreesPerSecond = TurnSpeed;
                var absDegreesLeftToRotate = Mathf.Abs(degreesLeftToRotate);
                // Do we have anymore distance to rotate?
                if (absDegreesLeftToRotate > 0)
                {
                    // Get the number of degrees to rotate this frame.
                    var degreesToRotate = degreesPerSecond * Time.deltaTime;

                    // Now apply the sign portion of direction to the degrees.
                    degreesToRotate *= directionMultiplier;

                    // Ensure that we don't rotate past our target.
                    degreesToRotate = Mathf.Clamp(degreesToRotate, -absDegreesLeftToRotate, absDegreesLeftToRotate);

                    // Now we should be good to go ahead and rotate.
                    transform.parent.Rotate(degreesToRotate, 0, 0, Space.Self);

                    // Since we've rotated a bit then we need to reduce the number of degrees left to rotate appropriately.
                    degreesLeftToRotate -= degreesToRotate;
                }
                else
                {
                    // Raise an event that we have finished turning the direction.
                    OnTurningEnd(currentDirection);

                    // Set current direction back to NONE so we can actually turn again.
                    currentDirection = Direction.NONE;
                }
            }
        }
    }
}
