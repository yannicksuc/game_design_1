﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        LevelController.Instance.StopGame(true);
    }
}
