using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 10;
    public Sprite[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public EnemyBehavior enemyBeh;
    private SpriteRenderer changeSprite;

    void Start()
    {
        changeSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            damage(1);
        }
        */
        if (health == 10)
            changeSprite.sprite = fullHeart;
        if (health == 9)
            changeSprite.sprite = hearts[0];
        if (health == 8)
            changeSprite.sprite = hearts[1];
        if (health == 7)
            changeSprite.sprite = hearts[2];
        if (health == 6)
            changeSprite.sprite = hearts[3];
        if (health == 5)
            changeSprite.sprite = hearts[4];
        if (health == 4)
            changeSprite.sprite = hearts[5];
        if (health == 3)
            changeSprite.sprite = hearts[6];
        if (health == 2)
            changeSprite.sprite = hearts[7];
        if (health == 1)
            changeSprite.sprite = hearts[8];
        if (health <= 0)
        {
            changeSprite.enabled = false;
            Destroy(gameObject);
        }
    }
    public void damage(int n)
    {
        health -= n;
    }
}
