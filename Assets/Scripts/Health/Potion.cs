using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{

    public int item_hp = 3;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {

            collision.SendMessageUpwards("gain_hp", item_hp);
            Destroy(gameObject);
        }
        
    }
    }

