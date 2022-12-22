using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField]
    GameObject songPlayer;

    GameMusic gm;
    bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        gm = songPlayer.GetComponent<GameMusic>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            Time.timeScale = 1;
            paused = false;
            gm.playCurrentSong();

        }


        else if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            Time.timeScale = 0;
            paused = true;
             gm.playPauseMenu();

        }
        
    }
}
