using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour {
    [SerializeField] AirCondition aircon;

    public void doWork() {
        if (aircon.on) {
            GameManager.inst.OnWorkDone();
        }
    }
}