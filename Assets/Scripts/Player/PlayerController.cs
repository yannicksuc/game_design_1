using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerConstitution constitution;
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public float movementSpeed = 1f;
    public float jumpSpeed = 5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        OnBreathingStepChanged();
    }

    void Update()
    {
        constitution.breath.StepChange.AddListener(OnBreathingStepChanged);

        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, rb.velocity.y);
        animator.SetFloat("Horizontal", rb.velocity.x);
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
