using System;
using UnityEngine;

namespace Menu
{
    public class GameOverOverlayUI : OverlayUI
    {
        private void Awake()
        {
            LevelController.Instance.onGameOver.AddListener(TogglePanel);
        }

        [SerializeField] private bool wonStatus;
        void TogglePanel(bool hasWon)
        {
            if (hasWon == wonStatus)
                TogglePanel();
        }
        public void NextLevel()
        {
            Time.timeScale = 1;
            if (LevelController.Instance.nextLevelName != null)
                ScenesInstanciable.Instance.LoadScene(LevelController.Instance.nextLevelName);
            else
                BackToMenu();
        }
    }
}
