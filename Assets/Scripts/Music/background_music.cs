using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_music : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.menu, 0.8f);
        AudioManager.instance.PlaySound(AudioManager.instance.menu_background, 0.8f,true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
