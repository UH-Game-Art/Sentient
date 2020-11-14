using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using UnityEngine;

public class charge_up1 : StateMachineBehaviour
{
    
    public int total;
    public MasterFun MF;
  
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        total = animator.GetInteger("timeto_charge");
        MF = FindObjectOfType<MasterFun>();
        MF.animCount(total);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

     
    }

  
}
