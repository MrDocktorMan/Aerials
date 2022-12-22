using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amitamovement : MonoBehaviour
{
    [Header("Normal Shit")]
    Rigidbody2D rb;
    AudioSource boomBox;
    AmitaSoundeffectsScript sod;



    [Header("Look at these")]
    public Vector2 velocity;
    public float SpeedMult; 
    public double orgDecRate;
    public bool sliding, pressR, pressL;
    public bool onPlatform;
    public int jumpMode;
    public float airtime;
    public int jumpStyle;
    public bool faceRight;
    public bool crouching;
    public float falltime;
    public float styleTimer;
    public bool crouchJumping;
    public bool longJumping;
    public bool Somersaulting;
    public bool slowing;
    public float onGroundTimer;
    

    [Header("Change these")]
    public float amitaSpeed;
    public double incRate;
    public double decRate;
    public float slideRate;
    public float TJT; //TJT stands for triple jump timer



    [Header("Jumping Vars")]

    public float maxDownVel;
    public float gravDown;
    public float jumpVel;
    public float jumpCond;
    public float crJmpDis;
    public float lJmpDis;
    public float SomerDis;
    public float longHeight;
    public float crouchHeight;
    public float TripleHeight;
    public float SomerHeight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boomBox = GetComponent<AudioSource>();
        sod = GetComponent<AmitaSoundeffectsScript>();
        orgDecRate = decRate;
    }

    // Update is called once per frame
    void Update()
    {

        walkingMovement();


        // jump gravity
        if ((velocity.y > -maxDownVel && !onPlatform))
        {
            velocity.y -= gravDown * Time.deltaTime;

        }


        switch (jumpStyle)
        {
            case 1:
                normalJump();
                break;

            case 2:
                SecondJump();
                break;

            case 3:
                TripleJump();
                break;
            case 4:
                CrouchJump();
                break;
            case 5:
                SlideJump();
                break;
            case 6:
                Somersault();
                break;

        }






        if (onPlatform == true && styleTimer > 0)
        {

            styleTimer -= Time.deltaTime;


        }

        if (slowing == false && jumpStyle == 6)
        {
            jumpStyle = 1;

        }


        if(onGroundTimer > 2)
        {
            valueResets();
        }

        if(airtime >= jumpCond)
        {
            jumpMode = 3;
        }



        }



    void FixedUpdate()
    {
        SpeedMult = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(SpeedMult * amitaSpeed, rb.velocity.y);
       // rb.MovePosition((Vector2)transform.position + velocity * Time.deltaTime);
    }




    

    //These are methods below





    //VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV







    private void walkingMovement()
    {


        


        /*
        //amita and her running 
        //speed mult basically is her speed
        //incrate is how fast she reaches her speed
        //decrate is how fast she slows down
        if (SpeedMult >= 0)
        {
            //stops player from changing movement when sliding
            if (sliding == false && crouching == false && crouchJumping == false && longJumping == false && Somersaulting == false)
            {

                if (Input.GetButton("Right"))
                {
                    slowing = false;
                    //press r makes it so that you can only slide right when its true
                    //before you could hold down right and slide infinitely
                    pressR = true;

                    if (SpeedMult < amitaSpeed)
                    {
                        SpeedMult += Time.deltaTime * incRate;

                    }


                }

                else
                { pressR = false; }
            }



            if (pressR == false && longJumping == false)
            {// this is what slows down the player
                //the bools allow the player 
                if (SpeedMult > 0)
                {
                    SpeedMult -= Time.deltaTime * decRate;
                    slowing = true;
                    if (Input.GetButton("Left") && onPlatform == true&& sliding == false && crouching == false)
                    { 
                    jumpStyle = 6;
                    }
                }
                else
                {
                    slowing = false;
                }

            }

        }


        






        //same thing but left
        //some values are negative because of the fact that its left
        if (SpeedMult <= 0)
        {
            if (sliding == false && crouching == false && crouchJumping == false && longJumping == false && Somersaulting == false)
            {

                if (Input.GetButton("Left"))
                {
                    slowing = false;
                    pressL = true;
                    if (SpeedMult > amitaSpeed * -1)
                    {
                        SpeedMult -= Time.deltaTime * incRate;

                    }

                }
                else
                { pressL = false; }

            }


            if (pressL == false && longJumping == false)
            {
                if (SpeedMult < 0)
                {
                    SpeedMult += Time.deltaTime * decRate;
                    slowing = true;
                    if (Input.GetButton("Right") && onPlatform == true && sliding == false && crouching == false)
                    {
                        jumpStyle = 6;
                    }

                }
                else
                {
                    slowing = false;
                }
            }


        }





        if (SpeedMult < .5 && SpeedMult > -.5 && sliding == true && Somersaulting == false)
        {
            jumpStyle = 1;


        }

        if (SpeedMult < .5 && SpeedMult > -.5 && Somersaulting == false )
        {
            sliding = false;
            decRate = orgDecRate;
            


        }

        */

        // end of amita's runs (hehe)

        if (Input.GetButton("Crouch") && sliding == false && SpeedMult == 0 && onPlatform == true && Somersaulting == false)
        {
            crouching = true;
            jumpStyle = 4;

        }
        else
        {
            crouching = false;
        }
        if (Input.GetButtonUp("Crouch") && crouchJumping == false && longJumping == false && Somersaulting == false)
        {
            jumpStyle = 1;

        }



        if (Input.GetButtonDown("Crouch") && sliding == false && SpeedMult != 0 && onPlatform == true)
        {
            pressR = false;
            pressL = false;
            decRate = slideRate;
            sliding = true;
            jumpStyle = 5;
        }



        velocity.x = (float)SpeedMult;

        if (velocity.x > 0 && onPlatform == true && Somersaulting == false)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            faceRight = true;
        }

        if (velocity.x < 0 && onPlatform == true && Somersaulting == false)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            faceRight = false;
        }


    }



    //these are the fucker jump methods





    private void normalJump()
    {
        //OH MOTHERFUCKER THIS IS WHERE SHIT GETS PAINFUL
        //WE DOING THE JUMP MECHANICS HOMIE







        if (Input.GetButtonDown("Jump") && jumpMode == 1)
        {
            sod.PlaySound(0);
            onPlatform = false;
            jumpMode = 2;
            styleTimer = TJT;

        }

        if (Input.GetButton("Jump") && jumpMode == 2 && airtime < jumpCond)
        {
            velocity.y = jumpVel;

            airtime += Time.deltaTime;

        }

        if ((Input.GetButton("Jump") == false && jumpMode == 2))
        {
            jumpMode = 3;
        }



    }


    private void SecondJump()
    {



        if (styleTimer <= 0)
        {
            jumpStyle = 1;
        }



        if (Input.GetButtonDown("Jump") && jumpMode == 1)
        {
            
            onPlatform = false;
            jumpMode = 2;
            styleTimer = TJT;
            sod.PlaySound(1);
        }

        if (Input.GetButton("Jump") && jumpMode == 2 && airtime < jumpCond)
        {
            velocity.y = jumpVel * 1.15f;

            airtime += Time.deltaTime;

        }



        if ((Input.GetButton("Jump") == false && jumpMode == 2))
        {
            jumpMode = 3;
        }





    }



    private void TripleJump()
    {

        
        if (styleTimer <= 0)
        {
            jumpStyle = 1;
        }




        if (Input.GetButtonDown("Jump") && jumpMode == 1)
        {

            onPlatform = false;
            velocity.y = TripleHeight;
            sod.PlaySound(2);

        }





    }

    private void CrouchJump()
    {
        
        if (Input.GetButtonDown("Jump") && jumpMode == 1)
        {

            onPlatform = false;
            velocity.y = crouchHeight;
            crouchJumping = true;
            sod.PlaySound(4);

        }

        if (faceRight == true && crouchJumping == true)
        {
            velocity.x = -1 * crJmpDis;
        }

        if (faceRight == false && crouchJumping == true)
        {
            velocity.x = crJmpDis;
        }



    }


    private void SlideJump()
    {
        
        if (Input.GetButtonDown("Jump") && jumpMode == 1)
        {

            onPlatform = false;
            velocity.y = longHeight;
            longJumping = true;
            sliding = false;
            sod.PlaySound(3);
        }

        if (faceRight == true && longJumping == true)
        {
            velocity.x = lJmpDis;
        }

        if (faceRight == false && longJumping == true)
        {
            velocity.x = -1 * lJmpDis;
        }


    }
    private void Somersault()
    {

        if (Input.GetButtonDown("Jump") && jumpMode == 1)
        {
            
            onPlatform = false;
            velocity.y = SomerHeight;
            Somersaulting = true;
            sod.PlaySound(5);

        }

        if (faceRight == true && Somersaulting == true)
        {
            velocity.x = -1 * SomerDis;
        }

        if (faceRight == false && Somersaulting == true)
        {
            velocity.x = SomerDis;
        }



    }

    public void valueResets()
    {
        onPlatform = true;
        velocity.y = 0;
        jumpMode = 1;
        airtime = 0;
        crouchJumping = false;

        Somersaulting = false;
        if (longJumping == true)
        {
            SpeedMult = 0;
        }
        longJumping = false;

        if (jumpStyle == 1)
        {
            jumpStyle += 1;
        }

        else if (jumpStyle == 2)
        {
            if ((SpeedMult > .5 || SpeedMult < -.5))
            {
                jumpStyle += 1;
            }
            else
            {
                jumpStyle -= 1;
            }
        }
        else
        {
            jumpStyle = 1;
        }
        onGroundTimer = 0;
    }


}
