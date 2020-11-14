using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    private static string GameScene = "SampleScene";
    private static string MenuScene = "Menu";


    public static void GoToScene()
    {
        SceneManager.LoadScene(GameScene);
    }
    public static void GoToMenu()
    {
        SceneManager.LoadScene(MenuScene);
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
