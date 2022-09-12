using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launching : MonoBehaviour
{
    
    public bool close = false;
    public bool ready = false;
    private int distance;
    private int time;
    private int answer;

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
                setFigures();
                // Start final question here
                Debug.Log(distance + " " + time + " " + answer);
            }
        }
    }

    public void setFigures()
    {
        distance = Random.Range(10000, 20000);
        time = Random.Range(3, 7);
        answer = distance / time;
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
