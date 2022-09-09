using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalVariables : MonoBehaviour
{
    public Text scoreText;
    private int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        scoreText.text = currentScore.ToString();
    }

    public void AddScore()
    {
        currentScore += 100;
        scoreText.text = currentScore.ToString();
    }

    public void addFinalScore()
    {
        // Need to add this depending on time
    }

}
