using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentBoxCrusher : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    GameObject Cwusher;


    float pBoxMovement = 0;




    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    public void pBoxSet(float yeah)
    {
        print("yeah = " + yeah);
        pBoxMovement = yeah;


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            isAmitaAirborne ab = collision.GetComponent<isAmitaAirborne>();

            if (ab.isAirborne() == false)
            {
                ab.setVelHorz(pBoxMovement);
                print("cheekclappin");

                
            }
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            isAmitaAirborne ab = collision.GetComponent<isAmitaAirborne>();
            ab.setVelHorz(0);
        }

    }


}
