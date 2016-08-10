using UnityEngine;
using System.Collections;
using Assets.Scripts.Interfaces;
using System;
using Assets.Scripts.Events;

public class GUIManager : MonoBehaviour, ISubscriber
{

    void OnEnable()
    {
        SubscribeToEvents();
    }

    private void OnPausedHandler(PausedEventArgs e)
    {
        // Toggle the visibility of the Pause GUI.
        transform.FindChild("Pause").gameObject.SetActive(e.IsPaused);
    }

    void OnDisable()
    {
        UnsubscribeFromEvents();
    }

    void OnGameOverHandler(GameOverEventArgs e)
    {
        // Show the GameOver GUI.
        this.transform.FindChild("Game Over").gameObject.SetActive(true);
    }

    // Implement ISubscriber Interface.
    public void SubscribeToEvents()
    {
        GameState.RaiseGameOverEvent += OnGameOverHandler;
        GameState.OnPaused += OnPausedHandler;
    }

    public void UnsubscribeFromEvents()
    {
        GameState.RaiseGameOverEvent -= OnGameOverHandler;
        GameState.OnPaused -= OnPausedHandler;
    }
}
