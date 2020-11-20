using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Rigidbody2D rb;
    boss_health bossH;
   

    // Start is called before the first frame update
    void Start()

    {
        bossH = FindObjectOfType<boss_health>();
        rb.velocity =  transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        /* **When enemy code is done**
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); 
        } */

       

        UnityEngine.Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Boss") {
            UnityEngine.Debug.Log("hit");
            bossH.BossDamage(3);
      
        }
        if (collision.gameObject.tag.Contains("Arm"))
        {
            bossH.BossDamage(3);
            UnityEngine.Debug.Log("hey");
        }
        Destroy(gameObject);
        
        
    }
}
