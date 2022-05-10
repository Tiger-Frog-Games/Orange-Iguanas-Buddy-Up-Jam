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

        #endregion
    }
}