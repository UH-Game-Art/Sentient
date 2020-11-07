using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelsScript : MonoBehaviour
{
    [SerializeField]
    int health = 3;

    [SerializeField]
    UnityEngine.Object destructableRef;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            health--;

            if (health <= 0)
            {
                ExplodeThisGameObject();
            }

        }



    }

    private void ExplodeThisGameObject()
    {
        
        GameObject destructable = (GameObject)Instantiate(destructableRef);


        //map the newly loaded destructable object to the x and y position of the previously destroyed barrel

        destructable.transform.position = transform.position;

        Destroy(gameObject);
       
    }


}
