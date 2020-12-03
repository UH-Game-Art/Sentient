using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_music : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // only play once in start
        AudioManager.instance.PlaySound(AudioManager.instance.menu, 0.8f);

    }

    // Update is called once per frame
    void Update()
    {
        //put it right here for looping
        AudioManager.instance.PlaySound(AudioManager.instance.menu_background, 0.8f, true);
    }
}
