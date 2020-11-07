using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public float movementSpeed = 1f;
    public float jumpSpeed = 5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, rb.velocity.y);
        animator.SetFloat("Horizontal", rb.velocity.x);
        //animator.SetFloat("Vertical", rb.velocity.y);
    }
}
