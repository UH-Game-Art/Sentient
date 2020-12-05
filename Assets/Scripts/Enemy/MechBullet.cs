using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechBullet : MonoBehaviour
{

    public float speed;
    public int damage;
    private Rigidbody2D rb;
    public PlayerMovement2 player;
    public float Bullet_Time = 0.5f;
    private bool playerFound = false;
    public PlayerHealth pb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, Bullet_Time);
        pb = FindObjectOfType<PlayerHealth>();
        if (player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement2>())
        {
            playerFound = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (playerFound)
            {
                player.Knockback(100f, player.transform.position);
                pb.damage(damage);
            }
            Destroy(gameObject, 0.01f); // destroy bullet if hit mob 
        }
    }
}
