using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Events;

namespace Assets.Scripts.Utils
{
    public abstract class APausable<T> : MonoBehaviour, ISubscriber, IPausable
    {
        protected T component;

        public abstract void PausedHandler(PausedEventArgs e);

        void Awake()
        {
            component = gameObject.GetComponent<T>();
        }
        public void OnEnable()
        {
            SubscribeToEvents();
        }

        public void SubscribeToEvents()
        {
            GameState.OnPaused += PausedHandler;
        }

        public void OnDisable()
        {
            UnsubscribeFromEvents();
        }

        public void UnsubscribeFromEvents()
        {
            GameState.OnPaused -= PausedHandler;
        }
    }
}
