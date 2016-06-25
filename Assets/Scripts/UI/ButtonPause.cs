using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonPause : MonoBehaviour
{
    public Sprite pauseSprite;
    public Sprite playSprite;

    private Image img;
    void Awake()
    {
        img = gameObject.GetComponent<Image>();
    }
    public void OnClick()
    {
        GameState.TogglePause();
        if(GameState.IsPaused)
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
