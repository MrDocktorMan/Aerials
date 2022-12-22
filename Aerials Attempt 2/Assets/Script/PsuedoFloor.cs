using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsuedoFloor : MonoBehaviour
{

    GameObject Player;
    float inputDir;
    PlatformEffector2D pe2;

    // Start is called before the first frame update
    void Start()
    {
        pe2 = transform.GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        inputDir = Input.GetAxisRaw("Vertical");

        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
        {

            if ((inputDir < 0)) //|| Player.transform.position.y < transform.position.y + 2.15f))
            { pe2.rotationalOffset = 180; }

            else //if (Player.GetComponent<isAmitaAirborne>().isAirborne().Equals(false))
            { pe2.rotationalOffset = 0; }

        }

    
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("touchy");
    }


}
