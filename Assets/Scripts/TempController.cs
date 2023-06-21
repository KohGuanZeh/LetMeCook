using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempController : MonoBehaviour {
    private AirCondition airCon;
    private Computer comp;
    private AudioSource thisAudio;
    void Start() {
        airCon = FindObjectOfType<AirCondition>();
        comp = FindObjectOfType<Computer>();
        thisAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            airCon.on = true;
            thisAudio.Play();
        }
    }
}
