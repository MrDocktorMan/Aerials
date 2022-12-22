using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collapse : MonoBehaviour
{
    public float falling;
    public float fallMount;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(falling > 0)
        {
            falling -= Time.deltaTime;

        }

        if(falling < 0)
        {

            Destroy(gameObject);
        }



    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            fallingPlat();
        }

    }



    void fallingPlat()
    {
        print("can you please fall for me?");
        falling = fallMount;
        rb.gravityScale = 1;


    }

}
