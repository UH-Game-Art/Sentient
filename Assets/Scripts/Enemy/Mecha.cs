using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Mecha : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float agroRange = 12f;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private int curHealth = 10;


    private float horMovement;
    private bool playerFound = false;
    private bool cannonCanShoot = true;
    private bool facingRight = false;
    private bool dead = false;

    private Animator animator;
    private Transform player;
    private Transform canon;
    private Rigidbody2D rb;

    private void Start()
    {
        if (player = GameObject.FindGameObjectWithTag("MechOnly").transform)
        {
            Debug.Log("Found Player" + player.name);
            rb = this.GetComponent<Rigidbody2D>();
            animator = this.GetComponent<Animator>();
            canon = this.gameObject.transform.GetChild(1).transform.GetChild(0).transform;
            Debug.Log(this.gameObject.transform.GetChild(1).transform.GetChild(0).name);
            playerFound = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canon.Rotate(Vector3.forward * 180);
        }
    }

    private void FixedUpdate()
    {
        if (playerFound && !dead)
        {
            //rb.velocity = new Vector2(horMovement * speed, rb.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
            float distToPlayer = Vector2.Distance(transform.position, player.position);

            // Check 2 different distances.
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
            else if (distToPlayer < agroRange && distToPlayer > attackRange)
            {
                if (transform.position.x < player.position.x)
                {
                    transform.localScale = new Vector2(1, 1);
                }
                else if (transform.position.x >= player.position.x)
                {
                    transform.localScale = new Vector2(-1, 1);
                }
            }

            if (transform.position.x < player.position.x && facingRight)
            {
                switchCanonPositions();
                facingRight = false;
            }
            else if (transform.position.x >= player.position.x && !facingRight)
            {
                switchCanonPositions();
                facingRight = true;
            }

            // Shoot if close to player.
            if (distToPlayer < agroRange && cannonCanShoot)
            {
                StartCoroutine(shoot());
            }

            if (curHealth < 0)
            {
                //Destroy(gameObject, 0.2f);
                gameObject.layer = LayerMask.NameToLayer("MechaDead");
                foreach (Transform trans in this.GetComponentsInChildren<Transform>(true))
                {
                    trans.gameObject.layer = LayerMask.NameToLayer("MechaDead");
                }
                animator.SetBool("Dead", true);
                dead = true;
            }
        }

    }

    private void switchCanonPositions()
    {
        canon.Rotate(Vector3.forward * 180);
    }

    private void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, agroRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void Damage(int dmg) // taking damage
    {
        curHealth -= dmg;
        StartCoroutine(Damaged_timer());
    }

    IEnumerator Damaged_timer()
    {
        Debug.Log("Your enter Coroutine at" + Time.time);
        yield return new WaitForSeconds(0.8f);
    }

    IEnumerator shoot()
    {
        //Instantiate your projectile
        Instantiate(bulletPrefab, canon.position, canon.rotation);
        cannonCanShoot = false;
        //Wait for some time
        yield return new WaitForSeconds(1f);
        cannonCanShoot = true;
    }
}