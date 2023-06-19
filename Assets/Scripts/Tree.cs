using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{   
    public Vector3 forAnim;
    public float upSpeed;
    bool ani = false;
    public Vector3 deathScale;
    public float scaleSpeed = 0.5f;
    public float threshold;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(ResourceManager.thisResource.pollutionLevel >= threshold) timeToDie();
    }

    // tree dying
    void timeToDie(){
        if(!ani){

            Vector3 newScale = transform.localScale * (1 + upSpeed * Time.deltaTime);
            newScale = Vector3.Max(newScale, forAnim);
            transform.localScale = newScale;
            if(transform.localScale.x >= forAnim.x) ani = true;
        }
        if(ani){

        scaleSpeed += Time.deltaTime;
        // Reduce the scale gradually over time
        Vector3 newScale = transform.localScale * (1 - scaleSpeed * Time.deltaTime * 2);

        // Ensure the scale does not go below the minimum value
        newScale = Vector3.Max(newScale, deathScale);

        // Apply the new scale
        transform.localScale = newScale;

        if(transform.localScale.x <= deathScale.x) gameObject.SetActive(false); // destroy when this object is at the end of its life
    }
    }
}
