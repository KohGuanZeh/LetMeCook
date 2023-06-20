using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    // for resourcesUsed
    public float waterUsed;
    public float wattUsed;
    public static ResourceManager thisResource;

    public GameObject[] trees;

    public float trashLevel;

    //dooms day
    public Color newcolor;
    public Light sun;
    public bool doomed = false;
    public Transform endTransform;
    public float lerpSpeed = 0.5f;
    private float t = 0f;
    [SerializeField] float threshHold;// to set phases of the world

    public float pollutionLevel;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if(thisResource !=null){
            GameObject.Destroy(thisResource);
        } else{
            thisResource = this;
            DontDestroyOnLoad(this);
        }

        trees = GameObject.FindGameObjectsWithTag("tree");
        
    }

    void Update(){
        if(pollutionLevel > threshHold){
            doomsday();
        }
        trashCalculator();
    }

    float trashCalculator(){
        return pollutionLevel = Mathf.FloorToInt((waterUsed + wattUsed + trashLevel)/5);
    }

    public float AddWatt(float value){
        return wattUsed += value;
    }
     public float AddWater(float value){
        return waterUsed += value;
    }

    public float AddTrash(float value){
         return trashLevel += value;
    }
    public void doomsday(){
        if(!doomed){

            t += lerpSpeed * Time.deltaTime;

        // Clamp t between 0 and 1 to ensure interpolation is within the valid range
            t = Mathf.Clamp01(t);

            sun.color = Color.Lerp(sun.color,newcolor, .5f/60);
            sun.transform.rotation = Quaternion.Lerp(transform.rotation, endTransform.rotation, t);
            if(t >= 0.6) doomed = true;
        }
    }
}
