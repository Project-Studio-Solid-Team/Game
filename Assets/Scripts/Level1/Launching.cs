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
    private float launchForce = 200;
    private AudioSource launchSound;

    // Question box for launch
    public GameObject lq;

    // Messages for player
    public GameObject nr;
    public GameObject r;

    // Get objective information from level vars
    public GameObject gv;

    void Start()
    {
        launchSound = this.GetComponent<AudioSource>();
    }

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
        distance = Random.Range(50, 100);
        time = Random.Range(3, 8);
        answer = Mathf.FloorToInt(distance / time);
        question.text = string.Format("Well done Time Lord! One last thing, I need to know what velocity is needed to get off this planet.\n\nUsing the rule Velocity = Distance / Time, could you tell me what it is? \n\nWe are {0} kilometres from the exit distance, and it will take us {1} minutes to get there. (Round down to the nearest whole number)", distance, time);
        lq.SetActive(true);

    }

    public void checkAnswer()
    {
        int ansInt = int.Parse(ans.GetComponent<TMP_InputField>().text);
        if (ansInt == answer)
        {
            Debug.Log(string.Format("The user answer is {0} and the correct answer is {1}", ansInt, answer));
            lq.SetActive(false);
            StartCoroutine(Launch());
        }
        else
        {
            // Play wrong sound here, show a popup showing "Wrong" for 1 second
        }
    }

    private IEnumerator Launch()
    {
        this.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        
        //Launch
        launchSound.Play();
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, launchForce));
        gv.GetComponent<GlobalVariables>().timerOn = false;
        yield return new WaitForSeconds(2.0f);
        gv.GetComponent<GlobalVariables>().LevelSuccess();
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
