using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arm_health : MonoBehaviour
{
    // Start is called before the first frame update
    public boss_health bMan;
    public int armHealth = 75;
    public int armCurrenthealth;
    public GameObject armDeath;
    private bool vun;
   

    void start()
    {
        armHealth = 75;
        bMan = FindObjectOfType<boss_health>();
        armCurrenthealth = armHealth;
    }
    void update()
    {
        vun = bMan.Bvun;
    }
    public void ArmDamage(int dam)
    {
        if (vun)
        {
            return;
        }
        else
        {
            armCurrenthealth -= dam;
        }
      
    }
 
}
