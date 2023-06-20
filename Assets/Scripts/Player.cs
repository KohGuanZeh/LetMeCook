using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float showerDuration = 0.0f;
    public bool doneShowering = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Shower" && !doneShowering) {
            if (showerDuration <= 7.0) {
                showerDuration += 0.01f;
            } else {
                doneShowering = true;
            }
        }
    }
}
