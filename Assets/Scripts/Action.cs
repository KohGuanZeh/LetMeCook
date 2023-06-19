// Base Class for any action related outcomes

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{
    // Override with good outcome things when creating
    // your own Action script
    public abstract void GoodOutcome();
    
    // Override with bad outcome things when creating
    // your own Action script
    public abstract void BadOutcome();
}
