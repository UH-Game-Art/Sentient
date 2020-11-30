using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tv_AI : MonoBehaviour
{
    public int curHealth = 5;
    public float distance;    // if player reach this distance, AI stop
   

  
    public Transform target; // target
   

    float scale = 2.0f;// scale mob size
    public Rigidbody2D r2;
    public Animator anim;

    private bool facingLeft = true;
    public bool awake = false; // Idle from begining
    public bool damaged = false;
    public bool atk = false;
    public bool laser = false;
    public bool shock = false;
    public bool switchattack = false;
    public int  attack_type=0;

    public bool death = false;

    public PlayerMovement2 player;

    public float moveSpeed; // need to set a value so it can move
    public float engageDistance = 10f;
    public float range; // to detect player range

    public float timeBtwShots;
    public float startTimeBtwShots; // set value for bullet spawn 

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement2>();
        anim = gameObject.GetComponent<Animator>();
        transform.localScale = new Vector3(scale, scale, scale);
        timeBtwShots = startTimeBtwShots;

    }

    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("Shock", shock);
        anim.SetBool("Laser", laser);
        anim.SetBool("death", death);
        anim.SetBool("Damged", damaged); // miss type damaged on animator tree
        anim.SetBool("SwitchAttack", switchattack);
        anim.SetInteger("Attack_Type", attack_type);
        range = Vector2.Distance(transform.position, target.position); // calculate player range
    }




    void FixedUpdate()
    {

        if (Vector3.Distance(target.position, this.transform.position) <= engageDistance) // if in range of detect player
        {
            awake = true; // awake is true then start walking
            attack_type = 0;// stop attack state when it walking

            if (range > 16)// move
            {
                awake = true;
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                attack_type = 0;
               
            }
            if (range<16 && range>9 )// if range is less than 15 and higher 9-> start shooting
            {
                awake = false;
                attack_type = 1;
               
            }

            if (range < 9)   // start shocking player
            {
               // awake = false;
                attack_type = 2;
            }

            if (target.transform.position.x > transform.position.x)  // flip side
            {
                transform.localScale = new Vector3(scale, scale, scale);
            }

            if (target.transform.position.x < transform.position.x)// flip side
            {
                transform.localScale = new Vector3(-scale, scale, scale);
            }




        }

        if (Vector3.Distance(target.position, this.transform.position) > engageDistance)
        {

            awake = false; // awake false -> idle state

        }

        if (curHealth <= 0)  // if mob hp<=0
        {

            death = true; // death animation
            Destroy(gameObject, 2.5f);


        }


    }




    public void Damage(int dmg) // taking damage
    {

        curHealth -= dmg;

        damaged = true;
        StartCoroutine(Damaged_timer());
    }

   


    IEnumerator switchAtk( ) // atk 2 to 1
    {
        attack_type = 0;
        Debug.Log("Your enter Coroutine at" + Time.time);
        yield return new WaitForSeconds(0.5f);
        attack_type = 1;

        // laser 1 time only

    }

    IEnumerator switchAtk2() // atk 1 to 2
    {
        attack_type = 0;
        Debug.Log("Your enter Coroutine at" + Time.time);
        yield return new WaitForSeconds(0.5f);
        attack_type = 2;

    }


    IEnumerator Damaged_timer()
    {

        Debug.Log("Your enter Coroutine at" + Time.time);
        yield return new WaitForSeconds(0.5f);
        damaged = false;  // laser 1 time only

    }

    private void OnTriggerEnter2D(Collider2D col)
    {


        if (col.CompareTag("Player"))
        {
            col.SendMessageUpwards("damage", 1);
            player.Knockback(100f, player.transform.position);  // the power to knock player back
            //  Destroy(gameObject, 0.1f);
        }

    }



}