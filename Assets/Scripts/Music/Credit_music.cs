using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit_music : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.credit, 0.7f, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
