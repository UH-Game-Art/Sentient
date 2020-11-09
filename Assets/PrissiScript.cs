using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrissiScript : MonoBehaviour
{
    [SerializeField]
    Transform castPoint;

    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSeePlayer(agroRange))

        {
            //agro enemy
            ChasePlayer();
        }
        else

        {
            StopChasingPlayer();
        }
    }
        
        bool CanSeePlayer(float distance)
        {
            bool val = false;
            float castDist = distance;

            Vector2 endPos = castPoint.position + Vector3.right * distance;

            RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));

            if(hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    val = true;
                }
                else
                {
                    val = false;
                }
            }
            return val;
        }
        void ChasePlayer()
        {
            if(transform.position.x < player.position.x)
            {
                //enemy is to the left side of the player, so move right
                rb2d.velocity = new Vector2(moveSpeed, 0);
                transform.localScale = new Vector2(-1, 1);

            }
            else if (transform.position.x > player.position.x)
            {
                //enemy is to the right side of the player, so move left
                rb2d.velocity = new Vector2(-moveSpeed, 0);
                transform.localScale = new Vector2(1, 1);
                
            }

            
        }

        void StopChasingPlayer()
        {

        }
    
}
