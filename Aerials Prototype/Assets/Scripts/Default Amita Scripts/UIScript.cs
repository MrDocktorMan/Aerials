using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScript : MonoBehaviour
{
    public int tokencur;
    public int tokenhigh;

    public Text tokenprint;

    // Start is called before the first frame update
    void Start()
    {
        tokenhigh = PlayerPrefs.GetInt("Tokens");
        tokenprint.text = tokencur.ToString() + " Tokens";
    }
    void Update()
    {
        tokenprint.text = tokencur.ToString() + " Tokens";
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            IncrementScore(1);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Token"))
        {
            IncrementScore(1);
            Destroy(other.gameObject);
        }
            
    }

    public void IncrementScore(int toAdd)
    {
        tokencur += toAdd;

        if(tokencur > tokenhigh)
        {
            tokenhigh = tokencur;
            PlayerPrefs.SetInt("Tokens", tokenhigh);
        }
    }
}
