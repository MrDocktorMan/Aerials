using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyFlyFly : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject barD;
    public GameObject barU;
    public bool up = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(barD.GetComponent<flip>().collided == true)
        {
            up = true;

        }

        if (barU.GetComponent<flip>().collided == true)
        {
            up = false;

        }


    }

    private void OnTriggerStay2D(Collider2D col)
        {
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();



        if (up == false)
            rb.gravityScale = 6;

       else if (up == true)
            rb.gravityScale = -6;


        }

    private void OnTriggerExit2D(Collider2D col)
    {
        Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 12;
        up = false;
    }

}
