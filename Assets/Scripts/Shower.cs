using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : MonoBehaviour
{
    [SerializeField] float showerDuration = 0.0f;
    [SerializeField] float showerTimeRequired = 5.0f;

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player" && showerDuration < showerTimeRequired) {
            showerDuration += 0.01f;
            if (showerDuration >= showerTimeRequired) {
                GameManager.inst.OnShowerTaken();    
            }
        }
    }
}
