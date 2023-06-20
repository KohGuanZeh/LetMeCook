using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utensils : MonoBehaviour {
    [SerializeField] Collider utensilHead;
    [SerializeField] bool hasFood = false;

    public void PickupFood(Transform foodTransform) {
        if (hasFood) {
            return;
        }

        foodTransform.parent = this.utensilHead.transform;
        foodTransform.localPosition = Vector3.zero;
        this.hasFood = true;
    }

    public void ResetPickup() {
        this.hasFood = false;
    }
}
