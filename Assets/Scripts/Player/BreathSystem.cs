using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

public class BreathSystem : MonoBehaviour
{
    [SerializeField] private PlayerConstitution constitution;

    enum Step
    {
        Inhale = 1,
        Exhale = -1
    }

    [SerializeField] private Step step = Step.Inhale;

    void Awake()
    {
        SetStep(step);
    }

    void SetStep(Step newStep)
    {
        step = newStep;
        if (step == Step.Inhale)
            constitution.breath.ratio = 0;
        else {
            constitution.breath.ratio = PlayerCharacteristic.Limit;
        }
    }

    // Update is called once per frame
    void Update()
    {
        constitution.breath.ratio += Time.deltaTime * PlayerCharacteristic.Limit / constitution.breath.cooldown * (float) step;

        if (step == Step.Inhale && constitution.breath.ratio >= PlayerCharacteristic.Limit)
            SetStep(Step.Exhale);
        else if (step == Step.Exhale && constitution.breath.ratio <= 0)
            SetStep(Step.Inhale);
    }
}
