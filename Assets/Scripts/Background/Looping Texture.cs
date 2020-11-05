using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingTexture : MonoBehaviour
{
    public float scrollSpeed = 0.5F;
    public float downSpeed = 0.0F;
    Vector3 origOffset;
    public Renderer rend;
    public bool randomizedAtStart;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        rend.materials.SetTextureOffset("_MainTex", new Vector2(Random.Range(-1f, 1f), 0));
        if (randomizedAtStart) origOffset = rend.material.GetTextureOffset("_MainTex");
                
    }

    
    void Update()
    {
        rend.material.SetTextureOffset("_MainTex", new Vector2(Time.time * scrollSpeed + origOffset.x, Time.time * downSpeed + origOffset.x));
        
    }
}
