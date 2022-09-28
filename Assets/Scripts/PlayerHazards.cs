using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHazards : MonoBehaviour
{
    public float delay = 1;
    public bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Laser());
    }

    // Coroutine goes here
    IEnumerator Laser(){
        yield return new WaitForSeconds(delay);
        if (active)
        {
           this.GetComponent<SpriteRenderer>().enabled = false;
           this.GetComponent<BoxCollider2D>().enabled = false;
           delay = 1.5f;
           active = false; 
        }
        else
        {
           this.GetComponent<SpriteRenderer>().enabled = true;
           this.GetComponent<BoxCollider2D>().enabled = true;
           delay = 2.5f;
           active = true; 
        }
        StartCoroutine(Laser());
    }
}
