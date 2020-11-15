using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesMoveTo : MonoBehaviour
{
    private Transform Target;
    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("TargetParticles").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position =  Vector3.MoveTowards(transform.position, Target.position, step);
    }
}
