using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAmita : MonoBehaviour
{


    public bool touchinGrass;
    [SerializeField]
    int amitaType;


    public int getType()
    {
        return amitaType;


    }    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            touchinGrass = true;

        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            touchinGrass = false;

        }
    }



}
