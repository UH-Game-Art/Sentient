using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob : MonoBehaviour
{
    public int curHealth = 100;
    public float distance;
    public float wakerange;
    public float shootinterval;
    public float bulletspeed = 5;
    public float bullettimer;


    public GameObject bullet; // mob bullet
    public Transform target; // target

    public Transform shootpointL, shootpointR; // shoot left or right

    float scale = 0.8f;// scale mob size
    public Rigidbody2D r2;
    public Animator anim;

    private bool facingLeft = true;
    public bool awake=true;



    public float moveSpeed;
    public float attackDistance = 3f;
    public float engageDistance = 10f;
    private float range; // to detect player range


    // Use this for initialization
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").transform;

        anim = GetComponent<Animator>();
        transform.localScale = new Vector3(scale, scale, scale);
    }


    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Awake", awake);
        range = Vector2.Distance(transform.position, target.position); // calculate player range

    }

    void FixedUpdate()
    {

        if (Vector3.Distance(target.position, this.transform.position) < engageDistance) // if in range of detect player
        {


            if (range > distance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                anim.Play("Walk");
            }


            if (target.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(scale, scale, scale);
            }

            if (target.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-scale, scale, scale);
            }




        }

        else
        {
            anim.Play("Idle");
        }
    }

   


    public void Damage(int dmg) // taking damage
    {
        curHealth -= dmg;
      //  gameObject.GetComponent<Animation>().Play("redflash");
    }
}