using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tv_AI : MonoBehaviour
{
    public int curHealth = 5;
    public float distance;    // if player reach this distance, AI stop


    public float TV_Death_Volume_Sound = 0.5f;
    public Transform target; // target
    public GameObject bullet;
    public Transform firePoint;
    //   public Transform firePointLeft;
    //  public Transform firePointRight;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
   


    public float scale = 0.8f;// scale mob size
    public Rigidbody2D r2;
    public Animator anim;

    private bool facingLeft = true;
    public bool awake = false; // Idle from begining
    public bool damaged = false;
    public bool atk = false;
    public bool laser = false;
    public bool shock = false;
    public bool switchattack = false;
    public bool isRight = true;
    public bool IsShooting = false;
    public int attack_type = 0;


    //bullet categorical
    public float bulletspeed = 5;
    public float bullettimer;

    public bool death = false;

    public PlayerMovement2 player;

    public float moveSpeed; // need to set a value so it can move
    public float engageDistance = 10f;
    public float range; // to detect player range

    public float timeBtwShots=2;
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
            IsShooting = false;

            if (range >8.5)// those range are base on final scene
            {
                awake = true;
              
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                attack_type = 0;

            }
            if (range < 8.5f && range > 5.5f)// if range is less than 15 and higher 9-> start shooting
            {
                awake = false;
                attack_type = 1;
                if (timeBtwShots <= 0  && attack_type==1)
                {
                    Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
                    timeBtwShots = startTimeBtwShots;
                }
                else
                {
                    timeBtwShots -= Time.deltaTime;
                }
            }

            if (range < 5)   // start shocking player
            {
                // awake = false;
              
                attack_type = 2;
            }

            if (target.transform.position.x > transform.position.x)  // flip side
            {
               
                transform.localScale = new Vector3(scale, scale, scale);// right
            }

            if (target.transform.position.x < transform.position.x)// flip side
            {
               
                transform.localScale = new Vector3(-scale, scale, scale); // left
            }




        }

        if (Vector3.Distance(target.position, this.transform.position) > engageDistance)
        {
            
            awake = false; // awake false -> idle state

        }

        if (curHealth <= 0)  // if mob hp<=0
        {
            attack_type = 0;
            AudioManager.instance.PlaySound(AudioManager.instance.ai_death, TV_Death_Volume_Sound);
           
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







    IEnumerator Damaged_timer()
    {

        Debug.Log("Your enter Coroutine at" + Time.time);
        yield return new WaitForSeconds(0.8f);
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

    public void Attack()
    {
         

    }


}