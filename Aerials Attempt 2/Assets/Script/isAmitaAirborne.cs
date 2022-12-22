using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isAmitaAirborne : MonoBehaviour
{
    bool airborne;
    float extraVelHorz = 0;
    float extraVelVert = 0;


    // Start is called before the first frame update

    private void Update()
    {
        //print(extraVelHorz);


    }


    public void airborneSet(int jp)
    {

        if (jp == 2)
        {
            airborne = true;

        }

        else
            airborne = false;


    }

    public float extraVelocityHorz()
    {
        
        return  extraVelHorz;


    }

    public void setVelHorz(float e)
    {
        print("E is " + e);
        extraVelHorz = e;
    }





    public float extraVelocityVert()
    {

        return extraVelVert;


    }

    public void setVelVert(float e)
    {
        extraVelVert = e;
    }


    public bool isAirborne()
    {
        return airborne;

    }


}
