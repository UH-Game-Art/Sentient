using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 10;
    public EnemyBehavior enemyBeh;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void damage(int n)
    {
        health -= n;
    }
}
