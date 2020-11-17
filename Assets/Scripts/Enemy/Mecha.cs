using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Mecha : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    private Rigidbody2D rb;
    private float horMovement;
    private bool facingRight;
    Animator animator;


    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        horMovement = Input.GetAxisRaw("Horizontal") * speed;

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horMovement * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(horMovement));

        // Flip player left or right based on direction hes looking at.
        if (facingRight == false && horMovement < 0)
        {
            flipPLayer();
        }

        else if (facingRight == true && horMovement > 0)
        {
            flipPLayer();
        }

    }

    // Funcion to flip the player if facing right/left.
    private void flipPLayer()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}

