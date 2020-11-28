using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public abstract class ABadEvent : MonoBehaviour
{
    [Tooltip("-1 is Infinite")]
    public int maxNbClone = 1;
    public new CinemachineVirtualCamera camera = null;

    protected virtual void Awake()
    {
        camera = Camera.main.GetComponent<CinemachineVirtualCamera>();
    }
}
