using Assets.Scripts.Interfaces;
using Assets.Scripts.PlayerScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class BuildingMover : MonoBehaviour, ISubscriber
    {
        public float minDistance;
        public float setBackAmount;
        void OnEnable()
        {
            SubscribeToEvents();
        }
        void OnDisable()
        {
            if (Player.Current != null)
            {
                UnsubscribeFromEvents();
            }
        }
        public void SubscribeToEvents()
        {
            Player.Current.OnMoved += OnPlayerMovedHandler;
        }

        public void UnsubscribeFromEvents()
        {
            Player.Current.OnMoved -= OnPlayerMovedHandler;
        }

        private void OnPlayerMovedHandler(float distance)
        {
            transform.Translate(new Vector3(distance, 0, 0), Space.World);
        }

        void Update()
        {
            if (transform.position.x > minDistance)
                transform.Translate(new Vector3(-setBackAmount, 0, 0), Space.World);
        }
    }
}
