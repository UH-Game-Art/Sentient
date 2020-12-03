using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditWait : MonoBehaviour
{
    
    public GameObject Credits;
    public float WaitTillCredits;
    void Start()
    {
        StartCoroutine(WaitForCredits());
    }

    
    IEnumerator WaitForCredits()
    {
        yield return new WaitForSeconds(WaitTillCredits);
        Credits.SetActive(true);
    }
}
