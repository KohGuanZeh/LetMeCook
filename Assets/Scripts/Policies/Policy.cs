using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Policy : MonoBehaviour {
    public abstract void OnPolicyAccept();
    public abstract void OnPolicyDecline();
}
