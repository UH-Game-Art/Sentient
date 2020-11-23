using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseMenuUI;
    public AudioMixer audioMixer;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
       PlayMenuSound(); 
       PauseMenuUI.SetActive(false);
       Time.timeScale = 1f;
       IsPaused = false;
    }

    void Pause()
    {
        PlayMenuSound();
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void LoadMainMenu()
    {
        Debug.Log("Loading Menu");
        PlayMenuSound();
        Time.timeScale = 1f;
        IsPaused = false;
        SceneManager.LoadScene("MainMenu");
        
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
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
