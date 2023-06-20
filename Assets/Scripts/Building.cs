using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    [SerializeField] int maxHeight;
    [SerializeField] float timeToFinishBuild = 3;
    float buildTimeSeconds = 0;
    float buildSpeed;
    [SerializeField] Vector3 localScale;
    [SerializeField] bool isBuilding;

    void Start() {
        this.timeToFinishBuild = this.timeToFinishBuild <= 0 ? 3 : this.timeToFinishBuild;
        this.buildSpeed = 1 / this.timeToFinishBuild * Time.fixedDeltaTime;
        this.localScale = this.transform.localScale;
        this.localScale.y = 0;
        this.transform.localScale = this.localScale;
        this.isBuilding = false;
        this.gameObject.SetActive(false);
    }

    void Update() {
        if (isBuilding) {
            this.buildTimeSeconds += this.buildSpeed;
            float y = Mathf.Lerp(0, this.maxHeight, this.buildTimeSeconds);
            this.localScale.y = y;
            this.transform.localScale = this.localScale;

            if (y >= this.maxHeight) {
                this.isBuilding = false;
            }
        }
    }

    public void StartBuilding() {
        this.isBuilding = true;
    } 
}