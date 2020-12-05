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


    private float horMovement;
    private bool playerFound = false;
    private bool cannonCanShoot = true;
    private bool facingRight = false;

    private Animator animator;
    private Transform player;
    private Transform canon;
    private Rigidbody2D rb;

    private void Start()
    {
        if (player = GameObject.FindGameObjectWithTag("Player").transform)
        {
            Debug.Log(player.name);
        }
        if (player = GameObject.FindGameObjectWithTag("Player").transform)
        {
            Debug.Log("Found Player");
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
        if (playerFound)
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

    IEnumerator shoot()
    {
        //Instantiate your projectile
        Instantiate(bulletPrefab, canon.position, canon.rotation);
        cannonCanShoot = false;
        //wait for some time
        yield return new WaitForSeconds(1f);
        cannonCanShoot = true;
    }
}