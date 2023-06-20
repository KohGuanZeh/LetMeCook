using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempController : MonoBehaviour
{

    public int roomTemp;
    public int globalTemp;
    public AirCondition airCon;


void Start(){
    roomTemp = 32;
    globalTemp = 37;
    airCon = FindObjectOfType<AirCondition>();
}
    // Update is called once per frame
    void Update()
    {
        ChangeTemp();
    }
    void ChangeTemp()
    {

        if (airCon.on)
        {
            roomTemp = airCon.temp;
        }
    }
}
