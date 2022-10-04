using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Web Webinteraction = new Web();
        string[] temp = Webinteraction.getScores(PlayerPrefs.GetString("usernamePlayer"), 10, 1);

        foreach(string temp2 in temp){ 
            Debug.Log(temp2);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
