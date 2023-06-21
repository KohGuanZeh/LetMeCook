using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shower : MonoBehaviour
{
    [SerializeField] float showerDuration = 0.0f;
    [SerializeField] float showerTimeRequired = 5.0f;
    [SerializeField] TextMeshProUGUI subtitle;

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player" && showerDuration < showerTimeRequired) {
            showerDuration += 0.01f;
            if (showerDuration >= showerTimeRequired) {
                GameManager.inst.OnShowerTaken();
                StartCoroutine(TextTimer(subtitle, "That was a good shower, time to get out."));
            }
        }
    }

    private IEnumerator TextTimer(TextMeshProUGUI subtitle, string text) {
        subtitle.text = text;
        yield return new WaitForSeconds (5);
        subtitle.text = "";
  }
}
