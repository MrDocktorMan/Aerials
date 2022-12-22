using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeAmita : MonoBehaviour
{

    //This code is a bit of a motherfucker, so Im actually commenting it

    public int changeType; // THis is the type of changer the object is
    [SerializeField]
    GameObject Player;//This is the current player
    [SerializeField]
    GameObject FormerPlayer; //This is the player that you delete

    bool isCol; 

    [Header("All of Da Amitas")]
    [SerializeField]
    GameObject[] amitaType; //Stores all types of Amitas



    private void Update()
    {
        if(Player == null)
        Player = GameObject.FindGameObjectWithTag("Player");

        //This altogether checks if its within a radius and if it is it will change when you press e
        if (isCol == true)
        {

            if (Player.GetComponent<BaseAmita>().getType() == 0)
            {
                amitaSwitch(); //Contains all the condtions for Amita's types
            }

            else
            {
                if (Input.GetButtonDown("Interact"))
                {
                    FormerPlayer = Player;
                    Instantiate(amitaType[0], transform.position, transform.rotation);
                    Destroy(FormerPlayer);
                }


            }


        }//End of the checking for collision


    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            print("Yes is true");
            isCol = true;



        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            isCol = false;

        }



    }


    void amitaSwitch()
    {

        switch (changeType)
        {
            case 1:
                if (Input.GetButtonDown("Interact"))
                {
                    FormerPlayer = Player;
                    Player = Instantiate(amitaType[1], transform.position, transform.rotation);
                    Destroy(FormerPlayer);
                }
                break;




        }

    }

}
