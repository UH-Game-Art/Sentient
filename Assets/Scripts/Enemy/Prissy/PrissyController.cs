using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrissyController : MonoBehaviour
{
    public float health = 10f;

    public Transform target;

    public float engageDistance = 10f;

    public float attackDistance = 3f;

    public float moveSpeed = 5f;

    private bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(target.position, this.transform.position) < engageDistance)
        {
            //get direction of target
            Vector3 direction = target.position - this.transform.position;

            if(Mathf.Sign(direction.x) == 1 && !facingLeft)
            {
                Flip();
            }

            else if(Mathf.Sign(direction.x) == -1 && !facingLeft)
            {
                Flip();
            }

            if (direction.magnitude >= attackDistance)
            {
                Debug.DrawLine(target.transform.position, this.transform.position, Color.yellow);

                if (facingLeft)
                {
                    this.transform.Translate(Vector3.left * (Time.deltaTime * moveSpeed));

                }
                else if (!facingLeft)
                {
                    this.transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed));

                }
            }

            if (direction.magnitude < attackDistance)
            {
                Debug.DrawLine(target.transform.position, this.transform.position, Color.red);
            }
        }
        else if (Vector3.Distance(target.position, this.transform.position) > engageDistance)
        {
            //do nothing
            Debug.DrawLine(target.position, this.transform.position, Color.green);

        }
    }

    private void Flip()
    {
        facingLeft = !facingLeft;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;


    }
}
