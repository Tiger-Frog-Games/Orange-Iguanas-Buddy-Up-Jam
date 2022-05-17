using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OrangeIguanas
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables

        [SerializeField] private string sceneName;
        [SerializeField] private GameObject settingsMenu;
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject controls;

        #endregion

        #region Unity Methods

        #endregion

        #region Methods

        public void LoadGame()
        {
            SceneManager.LoadScene(sceneName);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void ShowSettings()
        {
            settingsMenu.SetActive(true);

        }

        public void HideSettings()
        {
            settingsMenu.SetActive(false);

        }

        public void ShowControls()
        {
            controls.SetActive(true);

        }

        public void HideControls()
        {
            controls.SetActive(false);

        }

        #endregion
    }
}