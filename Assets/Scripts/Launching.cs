using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launching : MonoBehaviour
{
    
    public bool close = false;
    public bool ready = false;

    // Messages for player
    public GameObject nr;
    public GameObject r;

    // Get objective information from level vars
    public GameObject gv;

    // Update is called once per frame
    void Update()
    {
        // Check if objectives are complete
        if (gv.GetComponent<GlobalVariables>().CanLaunch())
        {
            ready = true;
        }

        // Check for input when ready and in range
        if (ready && close)
        {
         if (Input.GetKeyDown(KeyCode.E))
            {
                // Start final question here
                Debug.Log("Poopoo");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (ready)
        {
            Debug.Log("Ready");
            r.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            nr.GetComponent<SpriteRenderer>().enabled = true;
        }  
        close = true;         
    }

        private void OnTriggerExit2D(Collider2D collider)
    {
        if (ready)
        {
            r.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            nr.GetComponent<SpriteRenderer>().enabled = false;
        } 
        close = false;          
    }
}
