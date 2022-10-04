using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public GameObject rank;
    public GameObject user;
    public GameObject group;
    public GameObject score;

    // Start is called before the first frame update
    void Start()
    {
        //Webinteraction = new Web();
        //string[] temp = Webinteraction.getScores(PlayerPrefs.GetString("usernamePlayer"), 10, 1);

        /*foreach(string temp2 in temp){ 
            Debug.Log(temp2);
        }*/

        Transform[] ranks = rank.GetComponentsInChildren<Transform>();
        foreach (Transform child in ranks)
        {
            Debug.Log(child);
        }

    }
}   