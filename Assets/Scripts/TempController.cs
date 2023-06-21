using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempController : MonoBehaviour {
    public AirCondition airCon;

    void Start() {
        airCon = FindObjectOfType<AirCondition>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            airCon.on = true;
        }
    }
}
