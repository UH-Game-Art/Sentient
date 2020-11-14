using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    
    private PlayerHealth playerHealth;

    void Start() 
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Player fell to their death");
            playerHealth.health = 0;
        }
    }

   
}
