using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    
    public int startingLives;
    private int lifeCounter;

    private Text lifeText;
    // Start is called before the first frame update
    void Start()
    {
        lifeText = GetComponent<Text>();

        lifeCounter = startingLives;
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = "x " + lifeCounter;
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
