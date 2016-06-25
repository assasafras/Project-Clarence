using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnClicked()
    {
        SceneManager.LoadScene("Game");
    }
}