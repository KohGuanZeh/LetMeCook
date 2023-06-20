using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityExpansionPolicy : Policy
{
    [SerializeField] Building[] buildings;

    public override void OnPolicyAccept() {
        foreach (Building building in buildings) {
            building.gameObject.SetActive(true);
            building.StartBuilding();
        }
        // Increase Economy?
    }

    public override void OnPolicyDecline() {
        // Stagnant Economy?
    }
}
