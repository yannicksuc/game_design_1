using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFirstScene : MonoBehaviour
{
    [SerializeField]
    private string firstSceneName = null;

#if UNITY_EDITOR
    void Awake() {
        if (DevPreload.StartSceneName != null) {
            firstSceneName = DevPreload.StartSceneName;
        }
    }
#endif

    void Start()
    {
        print("LOAD");
        SceneManager.LoadScene(firstSceneName);
    }
}
