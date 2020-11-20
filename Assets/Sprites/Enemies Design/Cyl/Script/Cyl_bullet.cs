using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyl_bullet : MonoBehaviour
{
    
    public float speed;
    public int damage;
    public Rigidbody2D rb;

    private Transform player;
    private Vector2 target;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);

        rb.velocity = transform.right * speed;
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D col)
    {


        if (col.CompareTag("Player"))
        {

            col.SendMessageUpwards("damage", 1);
            Destroy(gameObject, 0.1f);
        }

    }

}
  
