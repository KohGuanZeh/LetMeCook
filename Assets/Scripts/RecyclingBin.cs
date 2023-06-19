using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclingBin : MonoBehaviour
{
    // Anyone know a better way to do this lol
    public static Action recyclingAction;

    // Start is called before the first frame update
    void Start()
    {
        recyclingAction = transform.parent.GetComponent<Action>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Check if trash is thrown into the right bin
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag(gameObject.tag))
        {
            col.gameObject.SetActive(false);
            recyclingAction.GoodOutcome();
        }
        else
        {
            col.gameObject.SetActive(false);
            recyclingAction.BadOutcome();
        } 
    }
}
