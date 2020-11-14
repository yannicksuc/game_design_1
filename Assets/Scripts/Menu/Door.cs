using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        _anim.SetBool("Open", true);
    }

    private void OnMouseExit()
    {
        _anim.SetBool("Open", false);
    }


    private void OnMouseDown()
    {
        MenuManager.Leave();
    }
}