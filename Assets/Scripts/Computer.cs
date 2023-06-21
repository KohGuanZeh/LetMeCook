using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Computer : MonoBehaviour
{
  AirCondition aircon;

  [SerializeField] public GameObject airconPromptText;
  [SerializeField] GameObject workCompletedText;

  void Start(){
    aircon = FindObjectOfType<AirCondition>();
  }

  public void doWork()
  {
    if (aircon.on){
      GameManager.inst.OnWorkDone();
      workCompletedText.SetActive(true);
      airconPromptText.SetActive(false);
    } else {
      airconPromptText.SetActive(true);
    }
  }

  private void OnTriggerEnter(Collider other){
    if (other.tag == "Player") {
      doWork();
    }
  }
}