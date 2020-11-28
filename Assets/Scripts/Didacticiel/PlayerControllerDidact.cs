using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class PlayerControllerDidact : MonoBehaviour
{
    [SerializeField] private PlayerConstitution constitution;
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public float movementSpeed = 1f;
    public float jumpSpeed = 5f;
    public bool canMove = false;
    public bool canJump = false;
    private int jumpCount;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator.SetFloat("BreathStep", -0.1f);

        constitution.breath.StepChange.AddListener(OnBreathingStepChanged);
    }

    void Update()
    {

            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
        if (canMove)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, rb.velocity.y);
        }
        animator.SetFloat("Horizontal", rb.velocity.x);
        constitution.velocity = rb.velocity;
    }

    private void OnBreathingStepChanged()
    {
        if (constitution.breath.Step == BreathStep.Inhale) {
            animator.SetFloat("BreathStep", 0.1f);
        }
        else if (constitution.breath.Step == BreathStep.Exhale) {
            animator.SetFloat("BreathStep", -0.1f);
        }
    }
}
