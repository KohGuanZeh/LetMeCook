using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum switches{
    light,
    water
}
public class Switch : MonoBehaviour
{
    public switches typeOfSwitch;
    public GameObject parent; // the light that this button will control

    // Add to electricity used
    public float useRate;
    public bool on;
    // Start is called before the first frame update
    void Start()
    {
        on = false;
        parent.SetActive(false);
        useRate = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(on && typeOfSwitch == switches.light){
            ResourceManager.thisResource.AddWatt(useRate/60);
        }
        
         if(on && typeOfSwitch == switches.water){
            ResourceManager.thisResource.AddWater(useRate/60);
        }
    }

    void OnTriggerEnter(Collider col){
        
        if(col.gameObject.tag == "Player"){
            print("isPlayer");
            if(on){
                parent.SetActive(false);
                on = false;
            }else{
                parent.SetActive(true);
                on = true;
            }
        }
    }
}
