using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    public GameObject pistol;
    public GameObject gun;
    public int Weapon = 0;

    void Update()
    {
        SwapWeapons();
       
    }

    void SwapWeapons()
    {
        if (Input.GetButtonDown("Swap"))
        {
            if (Weapon == 0)
            {
                pistol.gameObject.SetActive(false);
                gun.gameObject.SetActive(true);
                Weapon = 1;
            }
            else
            {
                gun.gameObject.SetActive(false);
                pistol.gameObject.SetActive(true);
                Weapon = 0;
            }
        }
    }
}
