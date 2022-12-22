using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmitaSounds : MonoBehaviour
{
    AudioSource aud;

    [SerializeField]

    AudioClip[] clips;
    /*
    This is for making new characters
    Each array is going to be filled with a different sound corresponding to their number
    0 | walk
    1-3 | jumps
    4 | hurt
    5-8 | crushed
    9 | death
    10 - 14 | misc
    15 sounds in total so far


     */
    
    
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }



    public void setSounds(AudioClip[] newAud)
    {
        clips = newAud;


    }

    public void playWalk()
    {



    }


}
