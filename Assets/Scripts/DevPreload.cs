using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevPreload : MonoBehaviour
{
#if UNITY_EDITOR
    public static string StartSceneName = null;

    void Awake()
    {
        if (IsLoaded()) {
            Destroy(this);
            return;
        }

        if (StartSceneName != null) {
            Debug.Log("Warning: multiple " + this + " in scene!");
            Destroy(this);
            return;
        }

        StartSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(StartSceneName);
    }

    private void Update() {
        if (IsLoaded())
            Destroy(this);
    }

    private bool IsLoaded()
    {
        return ScenesManager.Instance != null;
    }
#endif
}
