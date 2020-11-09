using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylAI : MonoBehaviour
{
    Animator animator;
    private string currentState;
    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;
    Rigidbody2D rb2d;

    public Transform firePoint;
    public GameObject bulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        //print("distance to player" + distToPlayer);
        if (distToPlayer < agroRange)
        {
            ChasePlayer();
        }

        else
        {
            StopChasingPlayer();
        }
    }

    void ChasePlayer()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }

        else if (transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        //animator.Play("Cylwalk");
        if(distToPlayer >10 )
        {
            ChangeAnimationState("Cylwalk");
            Shoot();
            //Invoke("Shoot", 1f);
        }
        else if (distToPlayer < 10)
            ChangeAnimationState("Cylatk");
        //Shoot();
    }

    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentState == newAnimation) return;

        animator.Play(newAnimation);
        currentState = newAnimation;
    }
}
