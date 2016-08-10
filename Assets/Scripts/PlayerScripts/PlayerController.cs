using Assets.Scripts.Enums;
using System;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class PlayerController : MonoBehaviour
    {
        public Vector2 inputAxis;

        public InputType input;

        void Update()
        {
            switch (input)
            {
                case InputType.Keyboard:
                    HandleInput();
                    break;
                case InputType.Gamepad:
                    HandleInput();
                    break;
                case InputType.Mobile:
                    HandleMobileInput();
                    break;
                default:
                    HandleInput();
                    break;
            }
        }

        private void HandleMobileInput()
        {
            throw new NotImplementedException();
        }

        private void HandleInput()
        {
            // Is the player firing primary weapon?
            if (Input.GetButton("Fire1"))
                Player.Current.isFiringPrimary = true;
            else
                Player.Current.isFiringPrimary = false;

            // Is the player firing secondary?
            if (Input.GetButton("Fire2"))
                Player.Current.isFiringSecondary = true;
            else
                Player.Current.isFiringSecondary = false;

            // Is the player moving, if so left or right?
            inputAxis.x = Input.GetAxis("Horizontal");
            // Are we going left, right or neither?
            if (inputAxis.x > 0)
                Player.Current.Turn(Direction.RIGHT);
            else if (inputAxis.x < 0)
                Player.Current.Turn(Direction.LEFT);

            // Is the player moving back or forward?
            inputAxis.y = Input.GetAxis("Vertical");
            if (inputAxis.y > 0)
                Player.Current.MoveSpeed += 0.005f;
        }
    }
}
