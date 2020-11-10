using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public float smoothtimeX, smoothtimeY;
    public Vector2 velocity;

    public GameObject player;

    public Vector2 minpos, maxpos;
    public bool bound;

    public float timeRemaining = 10.0f;

    // Use this for initialization
    void Start()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.theme, 0.5f, true);
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void FixedUpdate() // will update each 0.2s
    {
        float posX = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref velocity.x, smoothtimeX);
        float posY = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref velocity.y, smoothtimeY);
        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bound)
        {

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minpos.x, maxpos.x),
                Mathf.Clamp(transform.position.y, minpos.y, maxpos.y),
                Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z));

        }
    }
}