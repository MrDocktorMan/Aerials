using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderClimb : MonoBehaviour
{
    float inputDir;



    // Update is called once per frame
    void Update()
    {
        inputDir = Input.GetAxisRaw("Vertical");

    }

    public void climbConventions(Rigidbody2D amrb, spidermitaMovement sm)
    {





                if (inputDir != 0)
                {

                    amrb.gravityScale = 0;


                }

                else if (sm.jumpingMode == 2 || sm.jumpingMode == 3)
                {
                    sm.walkMode = 1;
                    amrb.gravityScale = 12;
                    amrb.drag = 2;

        }


            

        



    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        Rigidbody2D amrb;
        spidermitaMovement am;

        if (collision.CompareTag("Player") == true)
        {
            if (collision.transform.GetComponent<amitaMovement>() != null)
            {

                am = collision.transform.GetComponent<spidermitaMovement>();
                amrb = collision.gameObject.GetComponent<Rigidbody2D>();


                am.walkMode = 1;
                
            }

        }

    }


}
