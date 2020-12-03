using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;

    public bool dialogActive;

    void Update()
    {
        if(dialogActive && Input.GetKeyDown(KeyCode.Q))
        {
            dBox.SetActive(false);
            dialogActive = false;
        }
    }

    public void showBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }
}