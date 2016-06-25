using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonGoToMainMenu : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
