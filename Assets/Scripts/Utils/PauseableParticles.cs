using UnityEngine;
using System.Collections;
using Assets.Scripts.Events;
using Assets.Scripts.Interfaces;
using System;

namespace Assets.Scripts.Utils
{
    public class PauseableParticles : APausable<ParticleSystem>
    {
        public override void PausedHandler(PausedEventArgs e)
        {
            if (e.IsPaused)
                component.Pause();
            else
                component.Play();
        }
    }
}