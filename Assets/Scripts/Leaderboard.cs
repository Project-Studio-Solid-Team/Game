using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public GameObject user;
    public GameObject group;
    public GameObject score;

    private string[] usernames = new string[10];
    private string[] scores = new string[10];
    private string[] classes = new string[10];

    // Start is called before the first frame update
    void Start()
    {
        Web Webinteraction = new Web();
        string[] temp = Webinteraction.getScores(PlayerPrefs.GetString("usernamePlayer"), 10, 1);

        int position = 0;
        foreach(string temp2 in temp){ 
           string[] split = temp2.Split(':');
  
           usernames[position] = split[0];
           scores[position] = split[1];
           classes[position] = split[2];

           
           position++;

           
        }

      //  Transform[] ranks = rank.GetComponentsInChildren<Transform>();
       // foreach (Transform child in ranks)
       // {
       //     Debug.Log(child);
       // }

    }
}   