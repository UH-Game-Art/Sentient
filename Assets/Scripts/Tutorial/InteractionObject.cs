using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public bool key; // this item is a key
    public bool gun; // this is a gun
    public bool openable; // can be open
    public bool locked; // it is lock
    public bool talk; // npc talk?
    public bool talkItem; //if npc need a item
    public string Type; // for gun use

    public DialogueManager dMan = null;
    
    public string messageGood;
    public string messageBad;

    public GameObject itemNeeded;

    public void DoInteraction(){
        gameObject.SetActive(false);
    }

    public void Talks()
    {
        dMan = FindObjectOfType<DialogueManager>();
        dMan.showBox(messageGood);
    }

    public void Talks1()
    {
        dMan = FindObjectOfType<DialogueManager>();
        dMan.showBox(messageBad);
    }
}
