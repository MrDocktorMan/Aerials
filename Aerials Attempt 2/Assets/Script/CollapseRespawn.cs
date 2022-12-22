using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseRespawn : MonoBehaviour
{
    [SerializeField]
    GameObject newPlatform;
    [SerializeField]
    GameObject platform;
    float spawnCount;
    public float countAmount;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (platform == null)
        {
            if (spawnCount > 0)
                spawnCount -= Time.deltaTime;

            else
                platform = Instantiate(newPlatform, transform.position, transform.rotation);


        }

        else
        {
            spawnCount = countAmount;

        }


    }
}
