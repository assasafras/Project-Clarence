using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts.Events;
using Assets.Scripts.Enums;

public static class GameState
{

    public delegate void GameOverEventHandler (GameOverEventArgs e);

    public static event GameOverEventHandler RaiseGameOverEvent = delegate { };

    public delegate void PausedEventHandler (PausedEventArgs e);

    public static event PausedEventHandler OnPaused = delegate { };

    private static bool isPaused;
    public static bool IsPaused
    {
        get { return isPaused; }
        set
        {
            isPaused = value;
            OnPaused(new PausedEventArgs(value));
        }
    }
    public static void TogglePause()
    {
        IsPaused = !IsPaused;
    }

    public static void EndGame()
    {
        RaiseGameOverEvent(new GameOverEventArgs(GameOverStatus.lose));
    }
}
