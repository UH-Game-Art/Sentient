using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentientBunkertheme : MonoBehaviour
{


    public Transform player; // target
    public float bunker_volume=1.0f;
    public float forest_volume = 1.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >=-114 && player.transform.position.x<-54.27974) // if it is in bunker
        {
            AudioManager.instance.PlaySound(AudioManager.instance.Bunker_theme, bunker_volume, true);
        }

        if(player.transform.position.x >= -54.27974)// if it is in forest
        {
            AudioManager.instance.StopSound(AudioManager.instance.Bunker_theme); // stop bunker sound
            AudioManager.instance.PlaySound(AudioManager.instance.theme, forest_volume, true);// start forest song
        }
       

    }
}
