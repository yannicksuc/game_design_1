using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public MenuController mc;

    public enum DoorType
    {
        Exit,
        Play,
    }
    [SerializeField]
    private DoorType Type;
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
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
        if (Type == DoorType.Exit)
            MenuManager.Leave();
        else if (Type == DoorType.Play)
        {
            _anim.SetTrigger("Still");
            mc.StartCine();
        }
    }
}