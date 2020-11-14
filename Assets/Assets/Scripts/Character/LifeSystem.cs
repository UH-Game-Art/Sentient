using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeSystem : MonoBehaviour
{
    
    public int startingLives;
    private int lifeCounter;

    private Text lifeText;

    public GameObject GameOver;

    public float WaitGameOver;
    

    // Start is called before the first frame update
    void Start()
    {
        lifeText = GetComponent<Text>();
        lifeCounter = startingLives;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeCounter < 1)
        {
            GameOver.SetActive(true);
            Time.timeScale = 0.1f;
        }
        
        lifeText.text = "x " + lifeCounter;

        if(GameOver.activeSelf)
        {
            WaitGameOver -= Time.deltaTime;
        }

        if(WaitGameOver < 0)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void LifeUP()
    {
        lifeCounter++;
    }

    public void LifeDOWN()
    {
        lifeCounter--;
    }
}
