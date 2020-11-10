using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodedBarricade : MonoBehaviour
{
    public int item_hp = 3;

    [SerializeField]
    Vector2 forceDirection;

    [SerializeField]
    float torque;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(forceDirection);
        rb2d.AddTorque(torque);

        Invoke("DestroySelf", UnityEngine.Random.Range(1.5f, 3f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {

            collision.SendMessageUpwards("damage", item_hp);
            Destroy(gameObject);
        }

    }
    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
