using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public GameObject amita;
    amitamovement mov;
    amitaAnimations anim;
    AmitaSoundeffectsScript sod;

    

    // Start is called before the first frame update
    void Start()
    {
        mov = amita.GetComponent<amitamovement>();
        anim = amita.GetComponent<amitaAnimations>();
        sod = amita.GetComponent<AmitaSoundeffectsScript>();
    }


    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            mov.valueResets();
            sod.PlaySound(9);
            anim.anim.SetTrigger("Ground Collide");

            
        }




    }



    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {

            if (mov.onGroundTimer <= 2 && mov.onPlatform == false)
            {
                mov.onGroundTimer += Time.deltaTime;
            }

        }

        if (other.transform.CompareTag("Roof"))
        {
            mov.velocity.y = 0;

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            mov.jumpMode = 2;
            mov.onPlatform = false;
            
        }


    }



}
