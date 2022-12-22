using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausemenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject ost;
    public GameObject pauost;
    public bool Paused;
    AudioSource mus;
    AudioSource paumus;
    // Start is called before the first frame update
    void Start()
    {
        mus = ost.GetComponent<AudioSource>();
        paumus = pauost.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Esc"))
        {
            if (Paused == true)
            {
                resume();
                

            }
            else
            {
                pause();
            }
        }
    }

    private void pause()
    {
        Paused = true;
        Time.timeScale = 0f;
        menu.SetActive(true);
        mus.Pause();
        paumus.Play();
    }

    private void resume()
    {
        Paused = false;
        Time.timeScale = 1f;
        menu.SetActive(false);
        mus.Play();
        paumus.Stop();
    }




}
