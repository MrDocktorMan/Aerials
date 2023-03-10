using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    public GameObject height;
    public GameObject pBox;




    Rigidbody2D rb;
    public float moveUpSpeed;
    public float fallSpeed;
    float falling;
    float timerCool;
    public float coolDown;
    bool playerCollide;

    [SerializeField]
    int CrusherType;

    public int crusherPhase = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (CrusherType)
        {
            case 1:
                crusherDown();


                break;

            case 2:
                crusherUp();
                break;

            case 3:
                crusherRight();
                break;

            case 4:
                crusherLeft();
                break;

        }








        if(timerCool >= 0)
        {
            timerCool -= Time.deltaTime;
           // print(timerCool);
        }

        
            

        


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Floor") == true)
        { 
        if (crusherPhase == 1)
            crusherPhase = 2;

            if (crusherPhase == 3)
            {
                crusherPhase = 4;
                print("i did it");
            }
        }

        


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            if(playerCollide == true)
            {
                collision.transform.GetComponent<hurtAmita>().invokePerish();
                print("You crushed me!");

            }


        }



    }

    public void setCol(bool f)
    {
        playerCollide = f;

    }



    void crusherDown()
    {
        switch (crusherPhase)
        {
            case 1:
                rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;

                rb.velocity = new Vector2(rb.velocity.x, moveUpSpeed);
                break;

            case 2:
                rb.constraints = RigidbodyConstraints2D.FreezeAll;


                if (height.GetComponent<CrusherSee>().oShiet)
                {
                    crusherPhase = 3;
                }

                break;

            case 3:
                rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;

                if (falling < fallSpeed)
                    falling += .5f;


                rb.velocity = new Vector2(rb.velocity.x, -falling);
                timerCool = coolDown;
                break;

            case 4:
                rb.constraints = RigidbodyConstraints2D.FreezeAll;


                falling = 0;

                if (timerCool < 0)
                {
                    crusherPhase = 1;

                }
                break;


        }

    }

    void crusherUp()
    {
        switch (crusherPhase)
        {
            case 1:
                rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;

                rb.velocity = new Vector2(rb.velocity.x, -moveUpSpeed);
                break;

            case 2:
                rb.constraints = RigidbodyConstraints2D.FreezeAll;


                if (height.GetComponent<CrusherSee>().oShiet)
                {
                    crusherPhase = 3;
                }

                break;

            case 3:
                rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;

                if (falling < fallSpeed)
                    falling += .5f;


                rb.velocity = new Vector2(rb.velocity.x, falling);
                timerCool = coolDown;
                break;

            case 4:
                rb.constraints = RigidbodyConstraints2D.FreezeAll;


                falling = 0;

                if (timerCool < 0)
                {
                    crusherPhase = 1;

                }
                break;


        }
    }

    void crusherRight()
    {
        switch (crusherPhase)
        {
            case 1:
                rb.constraints = ~RigidbodyConstraints2D.FreezePositionX;
                rb.velocity = new Vector2(-moveUpSpeed, rb.velocity.y);
                pBox.GetComponent<parentBoxCrusher>().pBoxSet(-moveUpSpeed);
                break;

            case 2:
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                pBox.GetComponent<parentBoxCrusher>().pBoxSet(0);

                if (height.GetComponent<CrusherSee>().oShiet)
                {
                    crusherPhase = 3;
                }

                break;

            case 3:
                rb.constraints = ~RigidbodyConstraints2D.FreezePositionX;

                if (falling < fallSpeed)
                    falling += .5f;


                rb.velocity = new Vector2(falling, rb.velocity.x);
                pBox.GetComponent<parentBoxCrusher>().pBoxSet(falling);
                timerCool = coolDown;
                break;

            case 4:
                rb.constraints = RigidbodyConstraints2D.FreezeAll;


                falling = 0;
                pBox.GetComponent<parentBoxCrusher>().pBoxSet(0);
                if (timerCool < 0)
                {
                    crusherPhase = 1;

                }
                break;


        }
    }

    void crusherLeft()
    {

    }


}
