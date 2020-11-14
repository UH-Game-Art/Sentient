using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spin : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public Rigidbody2D rigbd;

    void Start()
    {
        rigbd.rotation = 90f;
    }
   
    void FixedUpdate()
    {
        rigbd.rotation += 60.0f;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

    }
}
