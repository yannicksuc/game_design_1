using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public Animator CameraAnimation;
    public Animator PlayDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCine();
    }

    public void LoadScene()
    {
        MenuManager.GoToScene();
    }

    public void StartCine()
    {
        PlayDoor.SetBool("Open", true);
        PlayDoor.SetTrigger("Still");
        CameraAnimation.SetTrigger("Start");
        StartCoroutine(CameraZoom());
    }

    IEnumerator CameraZoom()
    {
        yield return new WaitForSeconds(1);
        LoadScene();
    }
}
