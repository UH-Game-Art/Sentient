using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechBullet : MonoBehaviour
{

    public float speed;
    public int damage = 1;
    private Rigidbody2D rb;
    public PlayerMovement2 player;
    public float Bullet_Time = 0.5f;
    private bool playerFound = false;
    public PlayerHealth pb;


    // Start is called before the first frame update
    void Start()
    {
        pb = FindObjectOfType<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, Bullet_Time);
        if (player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement2>())
        {
            playerFound = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pb.damage(damage);
            Destroy(gameObject, 0.01f); // destroy bullet if hit mob 
        }
    }
}
