using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob : MonoBehaviour
{
    public int curHealth = 5;
    public float distance;
    public float wakerange;
    public float shootinterval;
    public float bulletspeed = 5;
    public float bullettimer;


    public GameObject Cyl_bullet; // mob bullet
    public Transform target; // target

    public Transform shootpoint; // shoot left or right

    float scale = 2.0f;// scale mob size
    public Rigidbody2D r2;
    public Animator anim;
  


    private bool facingLeft = true;
    public bool awake = false; // Idle from begining
    public bool die = false;
    public bool damaged = false;



    public float moveSpeed;
    public float attackDistance = 3f;
    public float engageDistance = 10f;
    public float range; // to detect player range

    public float timeBtwShots;
    public float startTimeBtwShots; // set value for bullet spawn 



    // Use this for initialization
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").transform;

        anim = GetComponent<Animator>();
        transform.localScale = new Vector3(scale, scale, scale);
        timeBtwShots = startTimeBtwShots;
    }


    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("die", die);
        anim.SetBool("damaged", damaged);
        range = Vector2.Distance(transform.position, target.position); // calculate player range

     
    }

    void FixedUpdate()
    {
        
        if (Vector3.Distance(target.position, this.transform.position) < engageDistance) // if in range of detect player
        {
            awake = true; // awake is true then start walking
            Attack();

            if (range > distance)// move
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                Attack();

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
            die = true;

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




    public void Attack()
    {
        if (timeBtwShots <= 0)
        {
            Vector2 direction = target.transform.position - transform.position;
            GameObject bulletclone;
            bulletclone = Instantiate(Cyl_bullet, shootpoint.transform.position, shootpoint.transform.rotation) as GameObject;
            bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;

            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}