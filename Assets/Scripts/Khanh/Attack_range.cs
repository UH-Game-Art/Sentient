using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_range : MonoBehaviour
{

    public mob1 mob;
    public bool isLeft = false; // detect player left or right


    private void Awake()
    {
        mob = gameObject.GetComponentInParent<mob1>();

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isLeft)
                mob.Attack(false);

            else
                mob.Attack(true);


        }
    }
}