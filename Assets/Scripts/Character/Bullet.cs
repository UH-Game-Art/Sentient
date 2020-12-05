using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Rigidbody2D rb;
    public float Bullet_Time = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, Bullet_Time);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            collision.SendMessageUpwards("Damage", damage);



             Destroy(gameObject,0.1f); // destroy bullet if hit mob 
        }


    }


   
}
