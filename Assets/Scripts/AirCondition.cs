using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCondition : MonoBehaviour
{
    public int temp;
    public bool on = false;
    public Animator airconAnim;
    public GameObject particle;

    public float lerpSpeed = 0.5f;
    public float t = 0f;
    private AudioSource thisAudio;
    // Start is called before the first frame update
    void Start()
    {
        on = false;
        airconAnim = GetComponent<Animator>();
        temp = 16;
        thisAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Anim();
    }

    void Anim()
    {
        if (on)
        {
            airconAnim.SetBool("on", on);
            thisAudio.Play();
           // particle.SetActive(true);
        }
        else
        {
            on = false;
            airconAnim.SetBool("on", on);
            thisAudio.Stop();
          //  particle.SetActive(false);
        }
    }

    int addTemp(int value)
    {
        return temp += value;
    }
    int decreaseTemp(int value)
    {
        return temp -= value;
    }
}
