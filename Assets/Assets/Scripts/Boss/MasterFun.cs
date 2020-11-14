using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterFun : MonoBehaviour
{
    // Start is called before the first frame update
    private int count = 4;
    private bool phase1 = true;
    private bool inPhase = false;


    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (count == 0)
        {
            if (!inPhase)
            {
                anim.SetInteger("timeto_charge", 0);
                inPhase = true;
                count = -1;
            }
            else
            {
                anim.SetInteger("timeto_charge", 4);
                inPhase = false;
                count = 4;
                if (!phase1) {
                    anim.SetBool("phase_1", false);
                }
                else
                {
                    anim.SetBool("phase_1", true);
                }
            }
        }
        
        
    }
    public void bossDeath()
    {
        anim.SetBool("is_dead", true);
    }

    public void animCount(int para)
    {
        count = para;
    }
    public void updateChargeCount()
    {
        count--;
        UnityEngine.Debug.Log(count);
    }
    public void updatePhaseCount()
    {
        count--;
        UnityEngine.Debug.Log(count);
        if (count == 0)
        {
            if (phase1)
            {
                phase1 = false;
            }
            else
            {
                phase1 = true;
            }
        }
    }
}