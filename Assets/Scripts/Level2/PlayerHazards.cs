using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHazards : MonoBehaviour
{
    public float timeOn;
    public float timeOff;
    private float delay = 1;
    public bool active = true;
    public GameObject levelVars;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Laser());
    }
    
    // Hazard check for player
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<TardisController2D>().TakeDamage();
            levelVars.gameObject.GetComponent<LevelVariables>().SetHits();
        }
    }

    // Coroutine goes here
    IEnumerator Laser(){
        yield return new WaitForSeconds(delay);
        if (active)
        {
           this.GetComponent<SpriteRenderer>().enabled = false;
           this.GetComponent<BoxCollider2D>().enabled = false;
           delay = timeOff;
           active = false; 
        }
        else
        {
           this.GetComponent<SpriteRenderer>().enabled = true;
           this.GetComponent<BoxCollider2D>().enabled = true;
           delay = timeOn;
           active = true; 
        }
        StartCoroutine(Laser());
    }
}
