using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Mecha : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float agroRange = 40f;
    [SerializeField] private float attackRange = 20f;

    private Transform player;
    private Rigidbody2D rb;
    private float horMovement;
    private bool facingRight;
    Animator animator;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            rb = this.GetComponent<Rigidbody2D>();
            animator = this.GetComponent<Animator>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(horMovement * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer < agroRange && distToPlayer > attackRange)
        {
            if (transform.position.x < player.position.x)
            {
                rb.velocity = new Vector2(speed, 0);
                transform.localScale = new Vector2(1, 1);
            }
            else if (transform.position.x >= player.position.x)
            {
                rb.velocity = new Vector2(-speed, 0);
                transform.localScale = new Vector2(-1, 1);
            }
        }


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

    private void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, agroRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}