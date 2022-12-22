using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isColliding : MonoBehaviour
{
    [SerializeField]
    GameObject crush;

    [SerializeField]
    int type;



    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            crush.GetComponent<Crusher>().setCol(true);


        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {

        crush.GetComponent<Crusher>().setCol(false);

        }
        
    }


   
}
