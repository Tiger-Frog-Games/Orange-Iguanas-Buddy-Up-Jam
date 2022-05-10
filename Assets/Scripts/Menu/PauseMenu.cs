using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OrangeIguanas
{
    public class PauseMenu : MonoBehaviour
    {
        #region Variables

        [SerializeField] private string menuPath;

        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject settingsMenu;


        #endregion

        #region Unity Methods

        public void Update()
        {
            if (Input.GetKeyDown("escape"))
            {
                if (settingsMenu.activeInHierarchy)
                {
                    pauseMenu.SetActive(false);
                    settingsMenu.SetActive(false);
                    return;
                }

                if (pauseMenu.activeInHierarchy)
                {
                    pauseMenu.SetActive(false);
                    settingsMenu.SetActive(false);
                    return;
                }

                if (!settingsMenu.activeInHierarchy || !pauseMenu.activeInHierarchy)
                {
                    pauseMenu.SetActive(true);
                    settingsMenu.SetActive(false);
                    return;
                }
            }
        }

        #endregion

        #region Methods

        public void pauseGame()
        {
            pauseMenu.SetActive(true);
        }

        public void resumeGame()
        {
            pauseMenu.SetActive(false);
        }

        public void showSettings()
        {
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }

        public void hideSettings()
        {
            pauseMenu.SetActive(true);
            settingsMenu.SetActive(false);
        }

        public void toMainMenu()
        {
            SceneManager.LoadScene(menuPath);
        }

        #endregion
    }
}