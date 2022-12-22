using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amitaMovement : MonoBehaviour
{
    isAmitaAirborne aita;
    private Rigidbody2D rb;

    //GameObject peck;
    
    [Header("Movement Stuff")]
    private float movement;
    float notMovement;
    public float jumpForce; //How high they jump
    public float speedMult; //How fast character moves
    bool facingRight = true;
    public int jumpingMode = 1; //Jump mode is the phase of a single normal jump, it determines when you can or can't hold down space bar
    float peckerTimer;
    public bool normalJump = true;
    public int walkMode = 1; //walk mode is the form of transportation the character is in, **1 = walking** **2 = climbing** **3 == swimming**

    [Header("Timer Shit")]
    public float airTimer; //actually calculates time spent in air
    public float orgAirTimer;//This determines how long you can jump into the air for on normal jumps

    [Header ("Floor Collider Stuff")]
    public bool isGrounded;
    public Transform groundCollider;
    public float checkRadius;
    public LayerMask whatIsGround;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aita = GetComponent<isAmitaAirborne>();
        
        //***Scrapped content***
        //peck = transform.Find("Pecker").gameObject;
        
    }


    private void OnEnable()
    {
        //Resets amita's rb stuff; Was originally set this way because of previous intentions

        rb = GetComponent<Rigidbody2D>();

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.mass = 15;
        rb.drag = 2;
        rb.gravityScale = 12;


    }


    // Update is called once per frame
    void FixedUpdate()
    {
        aita.airborneSet(jumpingMode); // this sets the airborne script so that you dont have to worry about not having it

        if(jumpingMode == 2)
            //I made sure to calculate the jump force in fixed update, that way the jumping isn't inconsistent


        isGrounded = Physics2D.OverlapCircle(groundCollider.position, checkRadius, whatIsGround); // THis is what allows the player to collide with the ground, instead of using the actual collider

        if (walkMode == 1)
            walkStuff();//Does all the walking movement stuff
        else if(walkMode == 2)
            climbStuff();
        else if (walkMode == 3)
        {
            swimStuff();

        }




        
    }

    void Update()
    {
        //pseudoFloorCheck();

        if (normalJump == true) 
            jumpingShit();

        if(jumpingMode != 2)
            Grounding();
        //myPecker();

        

    }


    //changes the character's face direction. it flips the entire object as well instead of simply changing sprite direction. This can be extremely useful for future codes
    void Flip()
    { 
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }


    void jumpingShit()
    {
        //As soon as the jump button is pressed, it runs these codes and turnes into jump mode 2
        if (Input.GetButtonDown("Jump") && jumpingMode == 1)
         {
            
            jumpingMode = 2;
            airTimer = orgAirTimer;
            StartCoroutine("AirJumpTimer");
                    
                    

         }

        //When the player lets go, or the airtimer is 0, the player will fall again. 
        if (Input.GetButtonUp("Jump") && jumpingMode == 2 || airTimer <= 0)
            jumpingMode = 3;




    }
    //Sets the player to be on the ground again.
    void Grounding()
    {
        if(isGrounded == true)
        {
            if (jumpingMode != 2)
            {
                jumpingMode = 1;
                airTimer = 0;
            }




        }



    }

    void walkStuff()
    {
        movement = Input.GetAxis("Horizontal");
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        rb.velocity = new Vector2(movement * speedMult + aita.extraVelocityHorz(), rb.velocity.y);


        if (facingRight == false && movement > 0)
        {
            if (isGrounded == true)
            {
                Flip();
            }

        }
        if (facingRight == true && movement < 0)
        {
            if (isGrounded == true)
            {
                Flip();
            }
        }

    }

    void climbStuff()
    {
        movement = Input.GetAxis("Vertical");
        notMovement = Input.GetAxis("Horizontal");
        rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;
        isGrounded = true;

        rb.velocity = new Vector2(rb.velocity.x + aita.extraVelocityHorz(), movement * speedMult);

        if (facingRight == false && notMovement < 0)
        {
            
                Flip();
            

        }
        if (facingRight == true && notMovement > 0)
        {
            
                Flip();
            
        }

    }

    void swimStuff()
    {
        movement = Input.GetAxis("Horizontal");
        notMovement = Input.GetAxis("Vertical");
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;


        rb.velocity = new Vector2(movement * speedMult + aita.extraVelocityHorz(), notMovement * speedMult);

        if (facingRight == false && movement > 0)
        {

            Flip();


        }
        if (facingRight == true && movement < 0)
        {

            Flip();

        }


    }




    IEnumerator AirJumpTimer()

    {
        while (airTimer > 0)
        {
            airTimer -= Time.deltaTime;
            yield return null;
        }

    }


   


}


//~~~~~~~~~~~~~~~~~~~~~~~~~~
//NNONONONO THESE ARE WORTHLESS CODES



/* void myPecker()
   {
       if (Input.GetButtonDown("Peck") && peckerTimer <= 0)
       {
           peck.tag = "Weaponized";
           peckerTimer = .6f;

       }
       if (peckerTimer >= 0)
       {
           peckerTimer -= Time.deltaTime;

       }
       else
           peck.tag = "Player";

   }
  */

/*
IEnumerator TJTMethod()

{
    while (TJT > 0)
    {
        if(isGrounded == true)
        { 
        TJT -= Time.deltaTime;
        if (TJT <= 0)
        {
            jumpStyle = 1;
        }

        }
        yield return null;
    }

}
*/



/* void pseudoFloorCheck()
 {

     switch(jumpingMode)
     {
         case 1:
             whatIsGround = (1 << 8) | (1 << 13);
             Physics2D.IgnoreLayerCollision(9, 13, false);
             break;
         case 2:
             whatIsGround = (1 << 8) | (1 << 13);
             Physics2D.IgnoreLayerCollision(9, 13, true);

             break;
         case 3:
             whatIsGround = (1 << 8) | (1 << 13);
             Physics2D.IgnoreLayerCollision(9, 13, true);
             break;


     }

 }*/