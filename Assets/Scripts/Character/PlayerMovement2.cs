using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{

    public CharacterController2D controller;

    public Animator animator;
    public Rigidbody2D r2;
    public Transform feet;
    [SerializeField] private LayerMask whatIsGround;

    float horizontalMove = 0f;
    public float runSpeed = 40f;
    private int extraJumps = 1;
    private int jumps = 1;
    bool jump = false;
    bool isGrounded = false;
    bool crouch = false;

    // Update is called once per frame



    void Start()
    {
        jumps = extraJumps;
        feet = this.transform.Find("right_foot");
        r2 = this.GetComponentInParent<Rigidbody2D>();
    }
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feet.position, 0.5f, whatIsGround);
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump") && jumps > 0)
        {
            AudioManager.instance.PlaySound(AudioManager.instance.jump, 1);
            jump = true;
            animator.SetTrigger("takeOff");
            animator.SetBool("IsJumping", true);
            jumps--;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (isGrounded)
        {
            jumps = extraJumps;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void Knockback(float Knockpow, Vector2 Knockdir)
    {
        r2.velocity = new Vector2(0, 0);
        r2.AddForce(new Vector2(Knockdir.x * Knockpow, Knockdir.y * Knockpow));
    }

}
