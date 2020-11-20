using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class explode : MonoBehaviour
{
    public GameObject explodeEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D miss)

    {
        Instantiate(explodeEffect, transform.position, transform.rotation);
    }
   
}
