using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public Rigidbody2D r2;
    public Animator anim;

    public int ourHealth;
    public int maxhealth = 5;
    public float death_time = 3;
    public float timeRemaining =3;

    // Start is called before the first frame update
    void Start()
    {

        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ourHealth = maxhealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (ourHealth <= 0)
        {
            anim.SetBool("Die", true);

         

           Death();
        }
    }

    void FixedUpdate()
    {
       
    }

    public void Death()
    {
   
        if (death_time == 0)
        {
            Object.Destroy(gameObject, 2.0f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // put player back to first spawn location
        }
        }

    public void Damage(int damage)
    {
        ourHealth -= damage;
      //  gameObject.GetComponent<Animation>().Play("redflash");
      // need a sprite for display player get damaged
    }

}