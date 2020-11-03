using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
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
        if (collision.gameObject.tag == "PlayerGround")
        {
            Destroy(gameObject);
        } 
    }
}
