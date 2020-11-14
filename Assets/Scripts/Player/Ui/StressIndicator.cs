using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

public class StressIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerConstitution constitution;
    [SerializeField] private Slider stressLevelIndicator;

    // Update is called once per frame
    void Update()
    {
        stressLevelIndicator.value = constitution.stress.Ratio / PlayerCharacteristic.Limit;
    }
}
