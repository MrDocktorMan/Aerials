using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    GameObject Player;
    float perishTimer;
    Vector2 previousPos;

    public float speed =1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");




        SmoothTranslation();
        if (Player.GetComponent<BaseAmita>().touchinGrass == true)
            transform.position = Vector2.Lerp(transform.position, Player.transform.position, Time.deltaTime * speed);



        if (Input.GetKeyDown("f"))
        {

            respawnFromPerish();
        }


        

    }



    public void respawnFromPerish()
    {

                Player.transform.position = transform.position;


    }

    public void setRespawn()
    {
        transform.position = Player.transform.position;

    }


    private IEnumerator SmoothTranslation()
    {


                yield return null;
    }

}
