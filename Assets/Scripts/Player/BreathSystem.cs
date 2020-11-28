using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

public class BreathSystem : MonoBehaviour
{
    [SerializeField] private PlayerConstitution constitution;
    [SerializeField] private AudioSource inhaleAudio;
    [SerializeField] private AudioSource exhaleAudio;

    void Awake()
    {
        constitution.breath.Step = BreathStep.Inhale;
    }

    // Update is called once per frame
    void Update() {
        constitution.breath.Ratio += Time.deltaTime * PlayerCharacteristic.Limit / constitution.breath.cooldown * (float)constitution.breath.Step;

        if (constitution.breath.Step == BreathStep.Inhale && constitution.breath.Ratio >= PlayerCharacteristic.Limit) {
            constitution.breath.Step = BreathStep.Exhale;
            if (exhaleAudio) {
                exhaleAudio.Play();
            }
        } else if (constitution.breath.Step == BreathStep.Exhale && constitution.breath.Ratio <= 0) {
            constitution.breath.Step = BreathStep.Inhale;
            if (inhaleAudio) {
                inhaleAudio.Play();
            }
        }
    }
}
