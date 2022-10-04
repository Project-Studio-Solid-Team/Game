using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public GameObject user;
    public GameObject group;
    public GameObject score;

    private string[10] usernames;
    private string[10] scores;
    private string[10] classes;

    // Start is called before the first frame update
    void Start()
    {
        Web Webinteraction = new Web();
        string[] temp = Webinteraction.getScores(PlayerPrefs.GetString("usernamePlayer"), 10, 1);

        int position =0;
        foreach(string temp2 in temp){ 

           string[] out = temp2.Split(":");
           usernames[index] = out[0];
           scores[index] = out[1];
           classes[index] = out[2];
        }

        Transform[] ranks = rank.GetComponentsInChildren<Transform>();
        foreach (Transform child in ranks)
        {
            Debug.Log(child);
        }

    }
}   