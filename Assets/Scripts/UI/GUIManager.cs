using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour
{

    void OnEnable()
    {
        GameState.OnGameOver += OnGameOverHandler;
        GameState.OnPaused += OnPausedHandler;
    }

    private void OnPausedHandler(bool isPaused)
    {
        transform.FindChild("Pause").gameObject.SetActive(isPaused);
    }

    void OnDisable()
    {
        GameState.OnGameOver -= OnGameOverHandler;
    }

    void OnGameOverHandler()
    {
        this.transform.FindChild("Game Over").gameObject.SetActive(true);
    }
}
