using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
   public void PlayGame()
   {
       Debug.Log("Play Game");
       PlayMenuSound();
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void QuitGame()
   {
       Debug.Log("Quit Game");
       PlayMenuSound();
       Application.Quit();
   }

   public void SetVolume(float volume)
   {
       audioMixer.SetFloat("Volume", volume);
   }

   public void PlayMenuSound()
   {
       AudioManager.instance.PlaySound(AudioManager.instance.menu_clicking, 0.8f);
   }
}
