using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("collected!");
        Destroy(gameObject);
        
    }
    }

