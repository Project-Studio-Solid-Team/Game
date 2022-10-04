using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Web Webinteraction = new Web();
        StartCoroutine(Webinteraction.getScores(PlayerPrefs.GetString("usernamePlayer"), 10, 1));
        string[] scores = Webinteraction.getoutput();
        Debug.Log(scores[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
