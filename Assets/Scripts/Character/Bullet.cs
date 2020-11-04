using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage=20;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity =  transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))  // check is it player object
        {
            collision.SendMessageUpwards("Damage", 20);
        }
    }
}
