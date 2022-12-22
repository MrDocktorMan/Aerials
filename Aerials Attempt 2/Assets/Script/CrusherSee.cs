using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherSee : MonoBehaviour
{
    public bool oShiet;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") == true)
        {
            oShiet = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") == true)
            oShiet = false;
    }

}
