using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public GameObject PausePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    public void Pause()
    {
        if (!PausePanel.activeSelf)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void BackMenuButton()
    {
        Time.timeScale = 1;
        MenuManager.GoToMenu();
    }
}
