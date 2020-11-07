using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

public class BreathIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerConstitution constitution;
    [SerializeField] private Slider breathLevelIndicator;

    // Update is called once per frame
    void Update()
    {
        breathLevelIndicator.value = constitution.breath.ratio / PlayerCharacteristic.Limit;
    }
}
