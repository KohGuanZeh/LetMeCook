using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamp : MonoBehaviour {

    [SerializeField] bool isApprovalStamp = true;

    void OnTriggerEnter(Collider other) {
        Policy policy = other.GetComponent<Policy>();
        if (policy != null) {
            if (isApprovalStamp) {
                Debug.Log("Yes");
                policy.OnPolicyAccept();
            } else {
                policy.OnPolicyDecline();
            }
        }
    }

}
