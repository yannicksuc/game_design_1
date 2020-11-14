using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class RandomLight : MonoBehaviour
{
    private float baseIntensity;
    private Light2D light2d;
    public float intensityRandomness = 0.1f;
    private float timeBetweenRandomness = 0.05f;
    private float timer;

    void Start()
    {
        light2d = GetComponent<Light2D>();
        baseIntensity = light2d.intensity;
        timer = timeBetweenRandomness;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f) {
            if (Random.Range(0, 2) == 0) {
                light2d.intensity = Random.Range(baseIntensity - intensityRandomness, baseIntensity + intensityRandomness + 0.001f);
            }
            timer = timeBetweenRandomness;
        }
    }
}
