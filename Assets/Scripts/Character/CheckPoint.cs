using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public LevelManager levelManager;

    void Start() 
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            levelManager.currentCheckpoint = gameObject;
            Debug.Log("Activated Checkpoint " + transform.position);
        }
    }
}
