using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerButton : MonoBehaviour
{
    public bool showerActive = false;
    public GameObject showerGameObj;

    void Update () {
        if (showerActive == true) {
            showerGameObj.SetActive(true);
        } else {
            showerGameObj.SetActive(false);
        }
    }
    
}
