﻿using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts.Events;
using Assets.Scripts.Enums;

public class GameState
{

    public delegate void GameOverEventHandler (GameOverEventArgs e);

    public static event GameOverEventHandler RaiseGameOverEvent = delegate { };

    public delegate void PausedEventHandler (PausedEventArgs e);

    public static event PausedEventHandler RaisePausedEvent = delegate { };

    private static bool _pause;
    public static bool IsPaused
    {
        get { return _pause; }
        set
        {
            _pause = value;
            RaisePausedEvent(new PausedEventArgs(value));
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
