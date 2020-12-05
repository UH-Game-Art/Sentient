using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyl_bullet : MonoBehaviour
{
    
    public float speed=2;
    public int damage=2;
    public float bullet_duration = 0.2f;
    public Rigidbody2D rb;

    private Transform player;
    private Vector2 target;

   


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        rb.velocity = transform.right * speed;
        Destroy(gameObject, bullet_duration);
        
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
      

    }
    private void OnTriggerEnter2D(Collider2D col)
    {


        if (col.CompareTag("Player"))
        {

            col.SendMessageUpwards("damage", damage);
            Destroy(gameObject, 0.1f);
        }

    }
   

}
  
