using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private bool playerEntered = false;
    private SpriteRenderer sr;
    public bool PlayerEntered {get=>playerEntered;}
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr != null)
            sr.color = new Color(0,0,0,0);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.GetComponent<PlayerControl>() != null)
            playerEntered = true;
    }
}
