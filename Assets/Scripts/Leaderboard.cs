using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    public GameObject user;
    public GameObject group;
    public GameObject score;

    private string[] usernames = new string[10];
    private string[] scores = new string[10];
    private string[] classes = new string[10];

    private TextMeshProUGUI TMPTemp;

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

        Transform[] users = user.GetComponentsInChildren<Transform>();
        

        for (int i = 1; i < users.Length; i++)
        {
            TMPTemp = users[i].GetComponentInChildren<TextMeshProUGUI>();
            Debug.Log(temp);
            TMPTemp.text = usernames[i-1];
        }

        Transform[] groups = group.GetComponentsInChildren<Transform>();
       

        for (int i = 1; i < groups.Length; i++)
        {
            TMPTemp = groups[i].GetComponentInChildren<TextMeshProUGUI>();
            Debug.Log(temp);
            TMPTemp.text = classes[i-1];
        }

        Transform[] scoress = score.GetComponentsInChildren<Transform>();
       

        for (int i = 1; i < scoress.Length; i++)
        {
            TMPTemp = scoress[i].GetComponentInChildren<TextMeshProUGUI>();
            Debug.Log(temp);
            TMPTemp.text = scores[i-1];
        }

    }
}   