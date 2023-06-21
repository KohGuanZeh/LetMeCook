using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (GameManager.inst.CanSleep()) {
                GameManager.inst.LoadNextPhase();
                GetComponent<AudioSource>().Play();
            } else {
                // Execute a prompt
            }
        }
    }
}
