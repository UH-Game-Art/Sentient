using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
    //[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    //[SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching
    private bool landed = false;
    const float k_GroundedRadius = 1.5f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    public Animator animator;
    public LayerMask Collission_Mask;
    public Collider2D GroundCheckCol;

    // Added by dont_call
    private Inventory inventory;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();


        // Added by dont_call
        inventory = new Inventory();
    }

    private void FixedUpdate()
    {
        Flip();
        bool wasGrounded = m_Grounded;
        m_Grounded = false;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
        
>>>>>>> parent of 1e002c19... Update to old rico
=======
        
>>>>>>> parent of 1e002c19... Update to old rico
=======
        
>>>>>>> parent of 1e002c19... Update to old rico

        
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> parent of 1e002c19... Update to old rico
=======
>>>>>>> parent of 1e002c19... Update to old rico
                animator.SetBool("IsJumping", false);
>>>>>>> parent of 1e002c19... Update to old rico
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

    }

    void Update()
    {
        if(landed == true)
=======
        if (landed == true)
>>>>>>> parent of 1e002c19... Update to old rico
        {
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }
<<<<<<< HEAD
=======

    }


    void OnTriggerEnter2D(Collider2D theCollision)
    {
        if (theCollision.gameObject.tag == "Ground only")
        {
            landed = true;
        }
>>>>>>> parent of 1e002c19... Update to old rico
    }

    


   

=======
=======
>>>>>>> parent of 1e002c19... Update to old rico
        if (landed == true)
        {
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }

    }


    void OnTriggerEnter2D(Collider2D theCollision)
    {
        if (theCollision.gameObject.tag == "Ground only")
        {
            landed = true;
        }
    }

<<<<<<< HEAD
>>>>>>> parent of 1e002c19... Update to old rico
=======
>>>>>>> parent of 1e002c19... Update to old rico
    


    public void Move(float move, bool crouch, bool jump)
    {
        // If crouching, check to see if the character can stand up
      /*  if (!crouch)
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }
        } */

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {

            // If crouching
          /*  if (crouch)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }

                // Reduce the speed by the crouchSpeed multiplier
                move *= m_CrouchSpeed;

                // Disable one of the colliders when crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
            }
            else
            {
                // Enable the collider when not crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            } */

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            
        }
        // If the player should jump...
        if (m_Grounded && jump)
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        Vector3 mPosition = Input.mousePosition;
        mPosition = Camera.main.ScreenToWorldPoint(mPosition);
        if(mPosition.x > transform.position.x && m_FacingRight == false)
        {
            m_FacingRight = true;
            transform.Rotate(0, 180, 0);

        }
        if (mPosition.x < transform.position.x && m_FacingRight == true)
        {
            m_FacingRight = false;
            transform.Rotate(0, 180, 0);
        }

    }

    //Lets Player move with platform
    //Make sure the BOX collider covers the entire player
    public void OnTriggerStay2D(Collider2D other)
    {

             if(other.gameObject.tag == "Platform")
            {
                Debug.Log("On Platform");
                transform.parent = other.transform;
 
            }

        if (other.gameObject.tag == "Ground")
        {
            landed = true;

        }


    }
    public void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "Ground")
        {
            landed = true;

        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
     if(other.gameObject.tag == "Platform")
        {
            Debug.Log("Off Platform");
            transform.parent = null;

         }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        if (other.gameObject.tag == "Ground")
        {
            landed = false;

        }

=======
=======
>>>>>>> parent of 1e002c19... Update to old rico
=======
>>>>>>> parent of 1e002c19... Update to old rico
        if (other.gameObject.tag == "Ground only")
        {
            landed = true;
        }
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 1e002c19... Update to old rico
=======
>>>>>>> parent of 1e002c19... Update to old rico
=======
>>>>>>> parent of 1e002c19... Update to old rico
    }

}
