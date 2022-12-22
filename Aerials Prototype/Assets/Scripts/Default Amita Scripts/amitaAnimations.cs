using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amitaAnimations : MonoBehaviour
{
    amitamovement mov;
    public Animator anim;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mov = GetComponent<amitamovement>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

            anim.SetInteger("Running", (int)mov.SpeedMult);



        anim.SetBool("Crouching", mov.crouching);
        anim.SetBool("Sliding", mov.sliding);
        

        anim.SetInteger("Jumpstyle", mov.jumpStyle);
        anim.SetBool("OnPlatform", mov.onPlatform);

        if (Input.GetButtonDown("Jump"))
        {

            anim.SetTrigger("JumpTrig");
           
        }

        if (mov.velocity.y <0 ||mov.airtime > mov.jumpCond)
        {
            anim.SetBool("GoingDown", true);
        }
        else
        {
            anim.SetBool("GoingDown", false);
        }

        if(mov.SpeedMult < mov.amitaSpeed && (mov.SpeedMult > mov.amitaSpeed*-1) && mov.SpeedMult != 0)
        {
            anim.SetBool("Slowing", true);

        }
        else
        {
            anim.SetBool("Slowing", false);
        }

        anim.SetBool("Long Jumping", mov.longJumping);


        if ((Input.GetButton("Left")) || (Input.GetButton("Right")))
            {
            anim.SetTrigger("RunTrig");
        }



    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            
        }



    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {

            
        }



    }

}
