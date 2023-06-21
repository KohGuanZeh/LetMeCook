using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Computer : MonoBehaviour
{
  AirCondition aircon;
  [SerializeField] TextMeshProUGUI subtitle;
  private AudioSource thisAudio;
  
  void Start(){
    thisAudio = GetComponent<AudioSource>();
  }
  public void doWork()
  {
    if (aircon.on){
      GameManager.inst.OnWorkDone();
      StartCoroutine(TextTimer(subtitle, "Work Completed"));
      thisAudio.Play();
    } else {
      StartCoroutine(TextTimer(subtitle, "Its too hot to do any work"));
    }
  }

  private void OnTriggerEnter(Collider other){
    if (other.tag == "Player") {
      aircon = FindObjectOfType<AirCondition>();
      doWork();
    }
  }

  private IEnumerator TextTimer(TextMeshProUGUI subtitle, string text) {
        subtitle.text = text;
        yield return new WaitForSeconds (5);
        subtitle.text = "";
  }
}