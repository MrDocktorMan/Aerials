using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtAmita : MonoBehaviour
{
    public int hp;
    public float iFrames;
    float theFrames;
    float hurtAsHellFrames;
    bool spawnPhase = false;

    respawn rp;
    Rigidbody2D rb;
    BoxCollider2D bd;

    // Start is called before the first frame update
    void Start()
    {
        rp = GameObject.FindGameObjectWithTag("Respawn").GetComponent<respawn>();
        rb = GetComponent<Rigidbody2D>();
        bd = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Normal I frames
        if(theFrames >= 0)
        {
            theFrames -= Time.deltaTime;

        }



        //-------------------
        //The Perish Respawn



        if (hurtAsHellFrames >= 0)
        {
            hurtAsHellFrames -= Time.deltaTime;
            
        }
        else
        {
            if (spawnPhase == true)
            {
                spawnPhase = false;
                bd.enabled = true;
                rb.bodyType = RigidbodyType2D.Dynamic;
                rp.respawnFromPerish();
                print("enabled");
            }

        }

        


    }

    


    public void invokeHit()
    {

        if (theFrames < 0)
        {
            hp--;

            theFrames = iFrames;
        }

        

        

    }

    public void invokePerish()
    {
        if (hurtAsHellFrames < 0) //&& theFrames < 0)
        {
            hp--;

            hurtAsHellFrames = iFrames;
            //theFrames = iFrames + 1f;

            bd.enabled = false;
            rb.bodyType = RigidbodyType2D.Static;
            spawnPhase = true;


        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            rp.GetComponent<respawn>().setRespawn();

        }
    }

}
