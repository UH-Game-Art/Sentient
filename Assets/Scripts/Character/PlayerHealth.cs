using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public int health = 10;
    public int maxHealth = 10;
    public int damageTaken;
    public Image[] hearts;
    public Image fullHeart;
    public Image emptyHeart;

    private LifeSystem lifeSystem;
    private LevelManager levelManager;

    private void Start()
    {
     
        lifeSystem = FindObjectOfType<LifeSystem>();
        levelManager = FindObjectOfType<LevelManager>();

        fullHeart.enabled = true;
        for(int i = 0; i < health-1; i++)
        {
            hearts[i].enabled = false;
        }
        emptyHeart.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            damage(1);
        }
        if (health == 10)
            fullHeart.enabled = true;
        if (health == 9) {
            hearts[0].enabled = true;
            for(int i = 1; i < health-1; i++)
            {
                hearts[i].enabled = false;
                fullHeart.enabled = false;
            }
        }
        if (health == 8)
        {
            hearts[1].enabled = true;
            for (int i = 0; i < health-1; i++)
            {
                if (i != 1)
                {
                    hearts[i].enabled = false;
                    fullHeart.enabled = false;
                }
            }
        }
        if (health == 7)
        {
            hearts[2].enabled = true;
            for (int i = 0; i < health-1; i++)
            {
                if (i != 2)
                {
                    hearts[i].enabled = false;
                    fullHeart.enabled = false;
                }
            }
        }
        if (health == 6)
        {
            hearts[3].enabled = true;
            for (int i = 0; i < health-1; i++)
            {
                if (i != 3)
                {
                    hearts[i].enabled = false;
                    fullHeart.enabled = false;
                }
            }
        }
        if (health == 5)
        {
            hearts[4].enabled = true;
            for (int i = 0; i < health-1; i++)
            {
                if (i != 4)
                {
                    hearts[i].enabled = false;
                    fullHeart.enabled = false;
                }
            }
        }
        if (health == 4)
        {
            hearts[5].enabled = true;
            for (int i = 0; i < health-1; i++)
            {
                if (i != 5)
                {
                    hearts[i].enabled = false;
                    fullHeart.enabled = false;
                }
            }
        }
        if (health == 3)
        {
            hearts[6].enabled = true;
            for (int i = 0; i < health-1; i++)
            {
                if (i != 6)
                {
                    hearts[i].enabled = false;
                    fullHeart.enabled = false;
                }
            }
        }
        if (health == 2)
        {
            hearts[7].enabled = true;
            for (int i = 0; i < health-1; i++)
            {
                if (i != 7)
                {
                    hearts[i].enabled = false;
                    fullHeart.enabled = false;
                }
            }
        }
        if (health == 1)
        {
            hearts[8].enabled = true;
            for (int i = 0; i < health-1; i++)
            {
                if (i != 8)
                {
                    hearts[i].enabled = false;
                    fullHeart.enabled = false;
                }
            }
        }
        if (health <= 0)
        {
            emptyHeart.enabled = true;
            for (int i = 0; i < health-1; i++)
            {
                    hearts[i].enabled = false;
                    fullHeart.enabled = false;
            }
            Debug.Log("You died");
            lifeSystem.LifeDOWN();
            health = 10;
            emptyHeart.enabled = false;
            Debug.Log("Player MAX HEALTH");

            AudioManager.instance.PlaySound(AudioManager.instance.death, 1.0f);
            Delay();

            levelManager.RespawnPlayer();
            
            
            
        }
    }
    
    public void damage(int damageTaken)
    {
        health -= damageTaken;
    }
    public void gain_hp(int value)
    {
        health =health+ value;
        if (health > maxHealth)
        {
            health = 10;
        }
    }

    IEnumerable Delay()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Delay 3s");
    }
}
