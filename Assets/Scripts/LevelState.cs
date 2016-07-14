using Assets.Scripts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using UnityEngine;

namespace Assets.Scripts
{
    public static class LevelState
    {
        public static int score { get; set; }
        public static int coinsCollected { get; set; }
        public static int PlayTime { get; set; }

        private static Timer _playTimer;

        public static void Initialize()
        {
            score = 0;
            coinsCollected = 0;
            PlayTime = 0;
            _playTimer = new Timer(1);
            // Subscribe to Events.
            SubscribeToEvents();
        }
        /// <summary>
        /// Subscribe to appropriate events. Ensure that all events subscribed to are unsubscribed in <see cref="UnsubscribeFromEvents"/>
        /// </summary>
        private static void SubscribeToEvents()
        {
            _playTimer.Elapsed += OnPlayTimerElapsed;
            GameState.RaisePausedEvent += OnPausedHandler;
        }

        /// <summary>
        /// Unsubscribe from all events subscribed to in <see cref="SubscribeToEvents"/>
        /// </summary>
        private static void UnsubscribeFromEvents()
        {
            _playTimer.Elapsed -= OnPlayTimerElapsed;
            GameState.RaisePausedEvent -= OnPausedHandler;
        }

        private static void OnPlayTimerElapsed(object sender, ElapsedEventArgs e)
        {
            PlayTime++;
        }

        private static void Dispose()
        {
            _playTimer.Dispose();
            UnsubscribeFromEvents();
        }

        private static void OnPausedHandler(PausedEventArgs e)
        {
            if (e.IsPaused)
                _playTimer.Stop();
            else
                _playTimer.Start();
        }
    }
}
