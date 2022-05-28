using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.GetComponent<PlayerControl>() != null) {
            collider.GetComponent<PlayerControl>().IsClimbing = true;
            collider.GetComponent<PlayerControl>().IsGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.GetComponent<PlayerControl>() != null) {
            collider.GetComponent<PlayerControl>().IsClimbing = false;
            collider.GetComponent<PlayerControl>().IsGrounded = false;
        }
    }
}
