using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public GameObject light;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (light.active == true)
        {
            light.SetActive(false);
          
        }
        else if (light.active == false)
        {
            light.SetActive(true);
        }
    }
}
