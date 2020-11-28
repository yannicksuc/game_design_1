using System;
using UnityEngine;

namespace Menu
{
    public class OverlayUI : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        public bool IsOn => panel.activeSelf;

        public void TogglePanel()
        {
            if (!panel.activeSelf)
            {
                panel.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                panel.SetActive(false);
                Time.timeScale = 1;
            }
        }

        public void BackMenuButton()
        {
            Time.timeScale = 1;
            print("LAOD NEW");
            ScenesManager.Instance.LoadScene(ScenesManager.MenuScene);
        }
    
        public void Restart()
        {
            Time.timeScale = 1;
            print("LAOD NEW 2");
            ScenesManager.Instance.LoadScene(ScenesManager.Instance.currentSceneName);
        }
    }
}