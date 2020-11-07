using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameDesign1/PlayerConstitution")]
public class PlayerConstitution : ScriptableObject
{
    public const float StressLimit = 1;

    [Range(0,StressLimit)]
    public float stressLevel;

    public int breathRhythm;
    public int breathPower;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
