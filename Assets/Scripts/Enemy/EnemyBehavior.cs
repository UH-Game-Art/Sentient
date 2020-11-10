using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Animator animator;
    public EnemyHealth health;
    public Bullet bullet_;
    public int newHealth;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (health.health <= 0)
        {
            animator.SetBool("Dead", true);
            Destroy(gameObject, 1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            health.damage(bullet_.damage);
            Destroy(collision.gameObject);
            Debug.Log("Bullet touched Enemy1");
            animator.SetBool("dmg", true);
        }
    }
}
