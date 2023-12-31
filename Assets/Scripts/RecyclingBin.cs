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

    [SerializeField] bool isFireplace = false;
    [SerializeField] Transform particleSpawnPos;

    void Start()
    {
        if (isFireplace) {
            return;
        }

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
                if (isFireplace) {
                    Vector3 pos = particleSpawnPos ? particleSpawnPos.position : transform.position;
                    Instantiate(fireSmoke, pos, Quaternion.Euler(0,0,0));
                } else {
                    trashes[curCapacity].SetActive(true);
                }
                curCapacity++;
                col.gameObject.SetActive(false);
                if (curCapacity == trashCapacity) {
                    GameManager.inst.OnRoomCleaned();
                }
            }
        }
    }
}
