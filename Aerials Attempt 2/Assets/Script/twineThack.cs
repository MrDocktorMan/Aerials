using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twineThack : MonoBehaviour
{
    public float bouncy;
    GameObject Player;
    bool colled;

    Rigidbody2D rb;
    int amitaVersion;


    private void Start()
    {

        
    }

    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        amitaVersion = Player.GetComponent<BaseAmita>().getType();
        rb = Player.gameObject.GetComponent<Rigidbody2D>();



        if (Input.GetButtonDown("Jump") && colled == true)
        {
            print("nword");
            rb.AddForce(transform.up * bouncy, ForceMode2D.Impulse);

        }



    }

    private void OnTriggerStay2D(Collider2D col)
    {



        switch (amitaVersion)
        {
            case 0:
                amitaMovement aM = col.gameObject.GetComponent<amitaMovement>();
                aM.normalJump = false;

                colled = true;
                break;

            case 1:
                spidermitaMovement sM = col.gameObject.GetComponent<spidermitaMovement>();
                sM.normalJump = false;

                colled = true;
                break;



        }


    }

    private void OnTriggerExit2D(Collider2D col)
    {


        switch (amitaVersion)
        {
            case 0:
                amitaMovement aM = col.gameObject.GetComponent<amitaMovement>();
                aM.jumpForce = 28;
                aM.normalJump = true;
                colled = false;
                break;

            case 1:
                spidermitaMovement sM = col.gameObject.GetComponent<spidermitaMovement>();
                sM.jumpForce = 28;
                sM.normalJump = true;
                colled = false;
                break;



        }




    }


}
