using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dHolder : MonoBehaviour
{
    public string dialogue;
    private DialogueManager dMan;
    public string message = "Hello";

    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
        dMan.showBox(message);
    }




}