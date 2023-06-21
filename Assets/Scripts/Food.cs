using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
    bool canBeEaten = false;
    Utensils usedUtensil;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "MainCamera" && this.canBeEaten) {
            this.usedUtensil.ResetPickup();
            GameManager.inst.OnFoodEaten();
            this.gameObject.SetActive(false);
        } else if (other.tag == "Utensil") {
            this.usedUtensil = other.GetComponent<Utensils>();
            this.usedUtensil.PickupFood(this.transform);
            this.canBeEaten = true;
        }
    }
}
