using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHurty : MonoBehaviour
{
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
        string colTag;
        
        colTag = collision.transform.tag;
        
       switch(colTag)
        {
            case "Player":
                collision.transform.GetComponent<hurtAmita>().invokePerish();
                break;
            case "Kaglin":
                break;
            case "Squirrel":
                break;
            case "Spider":
                break;


        }



    }

}
