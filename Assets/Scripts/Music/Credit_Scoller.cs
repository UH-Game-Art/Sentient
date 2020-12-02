using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit_Scoller : MonoBehaviour
{

    public Animator anim;
    public bool end;
    public float endtime=1.0f;
    void Start()
    {
        anim = GetComponent<Animator>();
        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("end", end);
        
    }

    void FixedUpdate()
    {
        StartCoroutine(timer());
        
    }

    IEnumerator timer()
    {
        
        Debug.Log("Your enter Coroutine at" + Time.time);
        yield return new WaitForSeconds(endtime);
        end = true;
    }

}