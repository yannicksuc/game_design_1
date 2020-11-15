using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEventExample : ABadEvent
{
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Bad Event activated : " + gameObject.GetInstanceID());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnDestroy()
    {
        Debug.Log("Bad Event deactivated: " + gameObject.GetInstanceID());
    }
}
