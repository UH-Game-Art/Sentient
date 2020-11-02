using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public Rigidbody2D r2;
    public Animator anim;

    public int ourHealth;
    public int maxhealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        ourHealth = maxhealth;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (ourHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // put player back to first spawn location
    }

    public void Damage(int damage)
    {
        ourHealth -= damage;
      //  gameObject.GetComponent<Animation>().Play("redflash");
      // need a sprite for display player get damaged
    }

}