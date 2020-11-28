using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{


    public static void GoToIntro()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.IntroScene);
    }

    public static void GoToScene()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.GameScene);
    }
    public static void GoToMenu()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.MenuScene);
    }

    public static void Leave()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }
}
