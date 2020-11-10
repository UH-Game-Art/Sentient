using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayMenu : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void play()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.click, 0.5f);
        SceneManager.LoadScene("Forest");
    }
}
