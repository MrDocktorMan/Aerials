using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    public bool collided = false;

    private void OnTriggerStay2D(Collider2D col)
    {
        collided = true;


    }

    private void OnTriggerExit2D(Collider2D col)
    {
        collided = false;
    }
}
