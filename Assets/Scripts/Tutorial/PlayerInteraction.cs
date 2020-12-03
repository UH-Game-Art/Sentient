using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public InteractionObject curInterObjScript = null;
    public test_Inventory invent;


    void Update(){
        if(Input.GetButtonDown("Interact") && currentInterObj){
            //if item is key, add to inventory
            if(curInterObjScript.key){
                invent.AddItem(currentInterObj);
            }

            //if place can be open, open it
            // if(curInterObjScript.openable ){
            //     if(curInterObjScript.locked){
            //         if(invent.FindItem(curInterObjScript.itemNeeded)){
            //             curInterObjScript.locked = false;
            //             //portal appear or somethin
            //             invent.DeleteItem(curInterObjScript.itemNeeded);
            //         }
            //     }
            // }

            //for npc to talk
            if(curInterObjScript.talk)
            {
                if(curInterObjScript.talkItem)
                {
                    if(invent.FindItem(curInterObjScript.itemNeeded))
                    {
                        curInterObjScript.Talks();
                        invent.DeleteItem(curInterObjScript.itemNeeded);
                    }
                    else
                    {
                        curInterObjScript.Talks1();
                    }
                }
                else
                {
                    curInterObjScript.Talks();
                }
                
            }
        }
        //for wep switching, maybe
        // if(Input.GetButtonDown("Gun1")){
        //     GameObject gun1 = invent.FindType("Gun1");
        //     if(gun1 != null){
        //         //Switch to gun 1
        //     }
        // }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("interactableObject")){
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            curInterObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("interactableObject")){
            if(other.gameObject == currentInterObj){
                currentInterObj = null;
                //curInterObjScript = null;
            }
        }
    }
}
