using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioArea : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    void Start() {
        GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.GetComponent<PlayerControl>() != null)
            SoundManager.Instance.playUISound(audioClip);
    }
}
