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
        SceneManager.LoadScene(IntroScene);
    }

    public static void GoToScene()
    {
        SceneManager.LoadScene(GameScene);
    }
    public static void GoToMenu()
    {
        SceneManager.LoadScene(MenuScene);
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
