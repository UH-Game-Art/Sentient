using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.theme2, 0.7f, true);
    }

    // Update is called once per frame
    void Update()
    {
     //   AudioManager.instance.PlaySound(AudioManager.instance.theme, 0.5f, true);
    }
}
