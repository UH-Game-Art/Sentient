using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Boss_Attacks : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform laser1;
    public Transform laser2;
    public Transform laser3;
    public Transform laser4;
    public Transform laser5;
    public Transform laser6;
    public Transform laser7;
    public Transform laser8;
    public Transform laser9;
    public Transform laser10;
    public Transform laser11;
    public Transform laser12;
    public Transform missel1;
    public Transform missel2;
    public Transform missel3;
    public Transform missel4;
    public Transform missel5;
    public GameObject las1;
    public GameObject las2;
    public GameObject las3;
    public GameObject las4;
    public GameObject las5;
    public GameObject miss;
    public float waitingTime1 = 1.0f;
    public int option;
    float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime1)
        {
            Shoot();
            timer = 0;
        }
    }

    void Shoot()
    {
        if (option == 1)
        {
            Instantiate(las1, laser1.position, laser1.rotation);
            Instantiate(las4, laser2.position, laser2.rotation);
            Instantiate(las1, laser3.position, laser3.rotation);
            Instantiate(las4, laser4.position, laser4.rotation);
            Instantiate(las1, laser5.position, laser5.rotation);
            Instantiate(las4, laser6.position, laser6.rotation);
            Instantiate(las1, laser7.position, laser7.rotation);
            Instantiate(las4, laser8.position, laser8.rotation);
            Instantiate(las1, laser9.position, laser9.rotation);
            Instantiate(las4, laser10.position, laser10.rotation);
            Instantiate(las1, laser11.position, laser11.rotation);
            Instantiate(las4, laser12.position, laser12.rotation);
        }
        if (option == 2)
        {
            Instantiate(las3, laser1.position, laser1.rotation);
            Instantiate(las2, laser2.position, laser2.rotation);
            Instantiate(las3, laser3.position, laser3.rotation);
            Instantiate(las2, laser4.position, laser4.rotation);
            Instantiate(las3, laser5.position, laser5.rotation);
            Instantiate(las2, laser6.position, laser6.rotation);
            Instantiate(las3, laser7.position, laser7.rotation);
            Instantiate(las2, laser8.position, laser8.rotation);
            Instantiate(las3, laser9.position, laser9.rotation);
            Instantiate(las2, laser10.position, laser10.rotation);
            Instantiate(las3, laser11.position, laser11.rotation);
            Instantiate(las2, laser12.position, laser12.rotation);
        }
        if (option == 3)
        {
            Instantiate(las5, laser1.position, laser1.rotation);
            Instantiate(las5, laser2.position, laser2.rotation);
            Instantiate(las5, laser3.position, laser3.rotation);
            Instantiate(las5, laser4.position, laser4.rotation);
            Instantiate(las5, laser5.position, laser5.rotation);
            Instantiate(las5, laser6.position, laser6.rotation);
            Instantiate(las5, laser7.position, laser7.rotation);
            Instantiate(las5, laser8.position, laser8.rotation);
            Instantiate(las5, laser9.position, laser9.rotation);
            Instantiate(las5, laser10.position, laser10.rotation);
            Instantiate(las5, laser11.position, laser11.rotation);
            Instantiate(las5, laser12.position, laser12.rotation);
        }
        if(option == 4)
        {
            Instantiate(miss, missel1.position, missel1.rotation);
            Instantiate(miss, missel2.position, missel2.rotation);
            Instantiate(miss, missel3.position, missel3.rotation);
            Instantiate(miss, missel4.position, missel4.rotation);
            Instantiate(miss, missel5.position, missel5.rotation);
        }
        
    }
}
