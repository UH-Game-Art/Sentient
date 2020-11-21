using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tv_AI : MonoBehaviour
{
    public int curHealth = 5;
    public float distance;
    public float wakerange;
    

  
    public Transform target; // target


    float scale = 3.0f;// scale mob size
    public Rigidbody2D r2;
    public Animator anim;

    private bool facingLeft = true;
    public bool awake = false; // Idle from begining
    public bool damaged = false;
    public bool atk = false;
    public bool laser = false;
    public bool shock = false;



    public float moveSpeed;
    public float attackDistance = 3f;
    public float engageDistance = 10f;
    public float range; // to detect player range

    public float timeBtwShots;
    public float startTimeBtwShots; // set value for bullet spawn 

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        anim = GetComponent<Animator>();
        transform.localScale = new Vector3(scale, scale, scale);
        timeBtwShots = startTimeBtwShots;

    }

    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("Shock", shock);
        anim.SetBool("Laser", laser);
        range = Vector2.Distance(transform.position, target.position); // calculate player range
    }




    void FixedUpdate()
    {

        if (Vector3.Distance(target.position, this.transform.position) < engageDistance) // if in range of detect player
        {
            awake = true; // awake is true then start walking
           

            if (range > distance)// move
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
              

            }
            if (range < distance)
            {
                awake = false;

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
            

            Destroy(gameObject, 2.5f);


        }


    }




    public void Damage(int dmg) // taking damage
    {

        curHealth -= dmg;

        damaged = true;
        StartCoroutine(timer());

    }


    IEnumerator timer()
    {

        Debug.Log("Your enter Coroutine at" + Time.time);
        yield return new WaitForSeconds(0.5f);
        damaged = false;
    }




   
}