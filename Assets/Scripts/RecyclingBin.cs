using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclingBin : MonoBehaviour
{
    [SerializeField]
    private int trashCapacity = 3;
    [SerializeField]
    private int curCapacity = 0;
    public GameObject[] trashes;
    public GameObject fireSmoke;
    // Start is called before the first frame update
    void Start()
    {
        trashes = new GameObject[trashCapacity];
        for (int i = 1; i <= trashCapacity; ++i)
        {
            trashes[i-1] = transform.GetChild(i).gameObject;
        }
    }

    // Check if trash is thrown into the right bin
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag(gameObject.tag))
        {
            if (curCapacity < trashCapacity)
            {
                //GameObject tempSmoke = Instantiate(fireSmoke, transform.position, Quaternion.Euler(0,0,0));
                col.gameObject.SetActive(false);
                trashes[curCapacity++].SetActive(true);
                if (curCapacity == trashCapacity) {
                    GameManager.inst.OnRoomCleaned();
                }
            }
        }
    }
}
