using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    private static string IntroScene = "Intro";
    private static string GameScene = "Gameplay";
    private static string MenuScene = "Menu";
    private static string DidacticielScene = "Didacticiel";


    public static void GoToIntro()
    {
        ScenesInstanciable.Instance.LoadScene(ScenesInstanciable.IntroScene);
    }

    public static void GoToScene()
    {
        ScenesInstanciable.Instance.LoadScene(ScenesInstanciable.GameScene);
    }
    public static void GoToMenu()
    {
        ScenesInstanciable.Instance.LoadScene(ScenesInstanciable.MenuScene);
    }

    public static void GoToDidact()
    {
        SceneManager.LoadScene(DidacticielScene);
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
