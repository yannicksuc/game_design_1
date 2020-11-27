using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    [SerializeField] private PlayerConstitution constitution;
    [SerializeField] private UnityEvent onGameOver;
    private bool _isGameOn = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isGameOn)
            return;

        if (constitution.stress.Ratio >= PlayerCharacteristic.Limit)
            StopGame();
    }

    private void StopGame()
    {
        onGameOver?.Invoke();
        _isGameOn = false;
    }
}
