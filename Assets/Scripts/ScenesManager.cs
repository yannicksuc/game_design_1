using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : IManager<ScenesManager>
{
    private List<string> _sceneHistory = new List<string>();
    [HideInInspector] public string currentSceneName = null;
    
    public const string IntroScene = "Intro";
    public const string GameScene = "Gameplay";
    public const string MenuScene = "Menu";

    public string LastScene => _sceneHistory.Count > 2 ? _sceneHistory[_sceneHistory.Count - 2] : string.Empty;

    void Awake()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode arg1)
    {
        TrySetCurrent(scene.name);
    }

    private bool TrySetCurrent(string sceneName)
    {
        if (currentSceneName == sceneName) return false;
        
        _sceneHistory.Add(sceneName);
        currentSceneName = sceneName;
        return true;
    }

    public void LoadScene(string newSceneName, bool addToHistory = true)
    {
        if (!TrySetCurrent(newSceneName)) return;

        // We launch the next scene if no transition animation is found. If there is the transition will call the method after finishing
        if (!SceneTransitionManager.Instance || !SceneTransitionManager.Instance.HasTransitions())
            ValidateSceneLoading();
        else
            SceneTransitionManager.Instance.LaunchCloseTransition();
    }
    public bool PreviousScene()
    {
        if (_sceneHistory.Count >= 2)
        {
            LoadScene(LastScene);
            return true;
        }
        return false;
    }

    public void ValidateSceneLoading()
    {
        if (string.IsNullOrEmpty(currentSceneName))
            return;
        SceneManager.LoadScene(currentSceneName);
    }
}
