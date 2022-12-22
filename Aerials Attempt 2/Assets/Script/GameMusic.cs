using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{

    AudioSource aud;
    AudioSource aumb;

    [SerializeField]
    GameObject Ambience;

    [SerializeField]
    AudioClip[] songClips;
    [SerializeField]
    AudioClip[] ambClips;


    int songMode;


    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        aumb = Ambience.GetComponent<AudioSource>();


        //Remove this later**********
        aud.clip = songClips[1];
        aumb.clip = ambClips[1];
        songMode = 1;
        aud.Play();
        aumb.Play();
        //thank yoou very much*************

    }

    // Update is called once per frame


    public void setCurrentSong(int i)

    {

        songMode = i;

    }


    public void playCurrentSong()
    {
        switch (songMode)
        {

            case 1:
                playHurricaneHeights();
                break;

                

        }

    }





    //----------------------------------
    //The Rest below here are all songs


    public void playPauseMenu()
    {
        aud.clip = songClips[0];
        aumb.Pause();
        aud.Play();

    }

    public void playHurricaneHeights()
    {
        aud.clip = songClips[1];
        aumb.clip = ambClips[1];
        aud.Play();
        aumb.Play();


    }




}
