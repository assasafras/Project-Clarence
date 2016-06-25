using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour {
   
    public void Clicked()
    {
        SceneManager.LoadScene("Game");
    }
}
