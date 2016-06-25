using UnityEngine;
using System.Collections;

public class PauseableParticles : MonoBehaviour
{
    ParticleSystem particles;

    void Awake()
    {
        particles = gameObject.GetComponent<ParticleSystem>();
    }

    void OnEnable()
    {
        GameState.OnPaused += OnPausedHandler;
    }

    void OnDisable()
    {
        GameState.OnPaused -= OnPausedHandler;
    }

    private void OnPausedHandler(bool isPaused)
    {
        if (isPaused)
        {
            particles.Pause();
        }
        else
        {
            particles.Play();
        }
    }
}
