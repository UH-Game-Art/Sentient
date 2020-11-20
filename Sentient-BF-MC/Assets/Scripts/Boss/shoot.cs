using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public Rigidbody2D rb;
    public PlayerHealth pb;
    
    // Update is called once per frame
    void Start()
    {     
        rb.velocity = transform.right * speed;
        pb = FindObjectOfType<PlayerHealth>();
        
    }

    
    void OnTriggerEnter2D(Collider2D hitInfo)

    {
        if(hitInfo.gameObject.tag == "Player")
        {
            pb.damage(1);
        }
        Destroy(gameObject);
    }

}
