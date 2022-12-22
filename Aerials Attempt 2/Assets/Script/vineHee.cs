using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vineHee : MonoBehaviour
{
    float inputDir;



    // Update is called once per frame
    void Update()
    {
        inputDir = Input.GetAxisRaw("Vertical");
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D amrb;
        amitaMovement am;

        if (collision.CompareTag("Player") == true)
        {
            if(collision.transform.GetComponent<amitaMovement>() != null)
            { 

            am = collision.transform.GetComponent<amitaMovement>();
                amrb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (inputDir != 0)
                {
                    print("Heeho");
                    am.walkMode = 2;
                    collision.transform.position = new Vector2(transform.position.x,collision.transform.position.y);
                    amrb.gravityScale = 0;
                    

                }
                
            else if (am.jumpingMode == 2)
                {
                    am.walkMode = 1;
                    amrb.gravityScale = 12;
                    

                }

            
            }

        }


        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        Rigidbody2D amrb;
        amitaMovement am;

        if (collision.CompareTag("Player") == true)
        {
            if (collision.transform.GetComponent<amitaMovement>() != null)
            {

                am = collision.transform.GetComponent<amitaMovement>();
                amrb = collision.gameObject.GetComponent<Rigidbody2D>();


                am.walkMode = 1;
                amrb.gravityScale = 12;
                amrb.drag = 2;
            }

        }

    }



}
