using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempController : MonoBehaviour {
    public AirCondition airCon;
    public Computer comp;

    void Start() {
        airCon = FindObjectOfType<AirCondition>();
        comp = FindObjectOfType<Computer>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            airCon.on = true;
            comp.airconPromptText.SetActive(false);
        }
    }
}
