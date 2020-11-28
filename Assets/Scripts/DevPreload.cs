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
            Destroy(gameObject);
            return;
        }

        if (StartSceneName != null) {
            Debug.Log("Warning: multiple " + this + " in scene!");
            Destroy(gameObject);
            return;
        }

        print("YLO");
        StartSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("_preload");
    }

    private void Update() {
        if (IsLoaded())
            Destroy(gameObject);
    }

    private bool IsLoaded()
    {
        print(ScenesManager.Instance);
        return ScenesManager.Instance != null;
    }
#endif
}
