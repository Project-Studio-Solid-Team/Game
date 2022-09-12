using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Launching : MonoBehaviour
{
    
    public bool close = false;
    public bool ready = false;
    public Text question;
    public GameObject ans;
    private int distance;
    private int time;
    private int answer;

    // Question box for launch
    public GameObject lq;

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
                Debug.Log(distance + " " + time + " " + answer);
            }
        }
    }

    public void setFigures()
    {
        distance = Random.Range(10000, 20000);
        time = Random.Range(3, 7);
        answer = distance / time;
        question.text = string.Format("Well done Time Lord! One last thing, I need to know what velocity is needed to get off this planet.\n\nUsing the rule Velocity = Distance / Time, could you tell me what it is? \n\nWe are {0} metres from the exit distance, and it will take us {1} minutes to get there.", distance, time);
        lq.SetActive(true);

    }

    public void checkAnswer()
    {
        int ansInt = int.Parse(ans.GetComponent<TMP_InputField>().text);
        if (ansInt == answer)
        {
            Debug.Log(string.Format("The user answer is {0} and the correct answer is {1}", ansInt, answer));
        }
        else
        {
            // Play wrong sound here, show a popup showing "Wrong" for 1 second
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
