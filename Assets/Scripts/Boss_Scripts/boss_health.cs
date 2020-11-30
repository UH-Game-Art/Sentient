using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_health : MonoBehaviour
{
    // Start is called before the first frame update
    public int bossHealth = 250;
    public int bArms = 12;
    public int bossCurrentHealth;
    public GameObject bossDeath;
    public bool Bvun = false;
    public health_bar healthbar;
    Animator anim;
    
    void Start()
    {
        bossHealth = 250;
        anim = GetComponentInChildren<Animator>();
        bossCurrentHealth = bossHealth;
        healthbar.SetMaxHealth(bossCurrentHealth);
    }
    public void Update()
    {
        if(bossCurrentHealth <= 50)
        {
            anim.SetBool("final_bool", true);
        }
        if(bArms <= 6)
        {
            anim.SetBool("final_bool", true);
        }

    }
    public void BossDamage(int dam)
    {
        if (Bvun)
        {
            return;
        }
        else
        {
            bossCurrentHealth -= dam;
            healthbar.setHealth(bossCurrentHealth);
        }
        if(bossCurrentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        anim.SetBool("is_dead", true);

    }
}
