using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class mob1 : MonoBehaviour
{

    public int curHealth = 100;

    public float distance;
    public float wakerange;
    public float shootinterval;
    public float bulletspeed = 5;
    public float bullettimer;

      public bool awake = false;
    public bool lookingRight = true;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootpointL, shootpointR;


   private void Awake()
    {
        anim = GetComponent<Animator>();

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       anim.SetBool("Awake", awake);
       anim.SetBool("LookRight", lookingRight);

        RangeCheck();

        if (target.transform.position.x > transform.position.x) // if player position is on right
        {
            lookingRight = true;
        }

        if (target.transform.position.x < transform.position.x)// if player position is on left
        {
            lookingRight = false;
        }

        if (curHealth <= 0)
        {
            anim.SetBool("Die", true);
            Destroy(gameObject, 2.0f); // destroy after 2s
        }
    }


    void RangeCheck() // check distancce between player and enemy
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance < wakerange)
            awake = true;

        if (distance > wakerange)
            awake = false;
    }

    public void Attack(bool attackright)
    {
        bullettimer += Time.deltaTime;

        if (bullettimer >= shootinterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            if (attackright)
            {
                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootpointR.transform.position, shootpointR.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;

                bullettimer = 0;
            }

            if (!attackright)
            {
                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootpointL.transform.position, shootpointL.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;

                bullettimer = 0;
            }
        }
    }

    public void Damage(int dmg) // taking damage
    {
        curHealth -= dmg;
      //  gameObject.GetComponent<Animation>().Play("redflash");
    }
}