using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmitaSoundeffectsScript : MonoBehaviour
{
    AudioSource boomBox;
    public AudioClip[] audclips;
    CollisionScript col;
    amitamovement mov;



    void Start()
    {
        boomBox = GetComponent<AudioSource>();
        mov = GetComponent<amitamovement>();
        col = GetComponent<CollisionScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlaySound(int aud)
    {
       

        boomBox.clip = audclips[aud];

        boomBox.Play();
    }
}
