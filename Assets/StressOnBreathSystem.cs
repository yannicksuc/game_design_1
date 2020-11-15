using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class StressOnBreathSystem : MonoBehaviour
{
    [SerializeField] private PlayerConstitution constitution;

    [SerializeField] private float breathLimitCooldown;
    private float _initialBreathCooldown;
    void Awake()
    {
        _initialBreathCooldown = constitution.breath.cooldown;
        breathLimitCooldown -= _initialBreathCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        constitution.breath.cooldown = _initialBreathCooldown + (breathLimitCooldown * constitution.stress.Ratio / PlayerCharacteristic.Limit);
    }

    private void OnDestroy()
    {
        constitution.breath.cooldown = _initialBreathCooldown;
    }
}
