using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Utils
{
    public class GameCommands : MonoBehaviour
    {

        public void GoToMainMenu()
        {
            LoadLevel("Menu");
        }

        public void RestartLevel()
        {
            LoadLevel(SceneManager.GetActiveScene().name);
        }


        public void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }

        public void TogglePause()
        {
            GameState.TogglePause();
        }
    }
}
