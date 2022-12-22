using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wooter : MonoBehaviour
{
    [SerializeField]
    GameObject horzLine;

    [SerializeField]
    float bouncy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D amrb;
        amitaMovement am;
        if (collision.CompareTag("Player") == true)
        {
            if (collision.transform.GetComponent<amitaMovement>() != null)
            {
                am = collision.transform.GetComponent<amitaMovement>();
                amrb = collision.gameObject.GetComponent<Rigidbody2D>();
                amrb.gravityScale = 0;
                amrb.drag = 0;
                am.walkMode = 3;

                if (collision.transform.position.y > horzLine.transform.position.y)
                {
                    collision.transform.position = new Vector2(collision.transform.position.x, horzLine.transform.position.y);
                    print("sickwaves");
                    //am.isGrounded = true;
                    //am.jumpingMode = 1;


                }

                else if(collision.transform.position.y == horzLine.transform.position.y)
                {
                    //am.isGrounded = true;
                    //am.jumpingMode = 1; 
                    if (Input.GetButtonDown("Jump"))
                    {
                        amrb.AddForce(transform.up * bouncy, ForceMode2D.Impulse);
                    }

                }




                else
                {
                    am.isGrounded = false;
                    am.jumpingMode = 3;


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

                amrb.gravityScale = 12;
                am.walkMode = 1;
                amrb.drag = 2;

            }
        }
    }




}
