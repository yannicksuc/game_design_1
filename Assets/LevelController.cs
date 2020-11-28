using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : IInstanciable<LevelController>
{
    [SerializeField] private PlayerConstitution constitution;
    public class GameOverEvent : UnityEvent<bool> {}
    public GameOverEvent onGameOver = new GameOverEvent();
    private bool _isGameOn = true;
    public string nextLevelName;

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

    public void StopGame(bool won = false)
    {
        onGameOver?.Invoke(won);
        _isGameOn = false;
    }
}
