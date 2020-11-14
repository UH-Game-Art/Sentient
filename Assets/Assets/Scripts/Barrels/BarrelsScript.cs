using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelsScript : MonoBehaviour
{
    public Bullet bullet_;
    [SerializeField]
    int health = 3;

    [SerializeField]
    UnityEngine.Object destructableRef;

    //materials
    private Material matwhite;
    private Material matDefault;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        matwhite = Resources.Load("whiteflash", typeof(Material)) as Material;
        matDefault = sr.material;
    }

    
    
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Destroy(collision.gameObject);
            health--;
            sr.material = matwhite;

            if (health <= 0)
            {
                ExplodeThisGameObject();
            }
            else
            {
                Invoke("ResetMaterial", .05f);
            }

        }

    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }

    private void ExplodeThisGameObject()
    {
        
        GameObject destructable = (GameObject)Instantiate(destructableRef);


        //map the newly loaded destructable object to the x and y position of the previously destroyed barrel

        destructable.transform.position = transform.position;

        Destroy(gameObject);
       
    }


}
