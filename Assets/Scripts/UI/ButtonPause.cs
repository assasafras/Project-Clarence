using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Events;
using System;

public class ButtonPause : MonoBehaviour
{
    public Sprite pauseSprite;
    public Sprite playSprite;

    private Image img;
    void Awake()
    {
        img = gameObject.GetComponent<Image>();
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

    private void PausedHandler(PausedEventArgs e)
    {
        if (GameState.IsPaused)
        {
            img.sprite = playSprite;
            img.rectTransform.Rotate(0, 0, -90);
        }
        else
        {
            img.sprite = pauseSprite;
            img.rectTransform.Rotate(0, 0, 90);
        }
    }
}
