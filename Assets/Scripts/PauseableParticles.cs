using UnityEngine;
using System.Collections;
using Assets.Scripts.Events;
using Assets.Scripts.Interfaces;
using System;

public class PauseableParticles : MonoBehaviour, ISubscriber
{
    ParticleSystem particles;

    void Awake()
    {
        particles = gameObject.GetComponent<ParticleSystem>();
    }

    void OnEnable()
    {
        SubscribeToEvents();
    }

    void OnDisable()
    {
        UnsubscribeFromEvents();
    }

    private void OnPausedHandler(PausedEventArgs e)
    {
        if (e.IsPaused)
        {
            particles.Pause();
        }
        else
        {
            particles.Play();
        }
    }
    // Implement ISubscriber interface.
    public void SubscribeToEvents()
    {
        GameState.RaisePausedEvent += OnPausedHandler;
    }

    public void UnsubscribeFromEvents()
    {
        GameState.RaisePausedEvent -= OnPausedHandler;
    }
}
