using UnityEngine;
using System.Collections;
using System;

public class GameState : MonoBehaviour
{

    public delegate void GameOver();

    public static void TogglePause()
    {
        IsPaused = !IsPaused;
    }

    public static event GameOver OnGameOver = delegate { };

    public delegate void Paused(bool isPaused);

    public static event Paused OnPaused = delegate { };

    private static bool _pause;
    public static bool IsPaused
    {
        get { return _pause; }
        set
        {
            _pause = value;
            OnPaused(value);
        }
    }


    // Use this for initialization
    void Start ()
    {
	    
	}

    public static void EndGame()
    {
        OnGameOver();
    }
}
