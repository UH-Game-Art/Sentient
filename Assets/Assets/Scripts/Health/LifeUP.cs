using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUP : MonoBehaviour
{
    private LifeSystem lifeSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        lifeSystem = FindObjectOfType<LifeSystem>();
    }

   void OnTriggerEnter2D(Collider2D col)
   {
       if(col.gameObject.tag == "Player")
       {
           lifeSystem.LifeUP();
           Destroy(gameObject);
       }
   }
}
