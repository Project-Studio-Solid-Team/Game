using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionData : MonoBehaviour
{
    public Questions questions;
    [SerializeField] private Text questionText;

    void Start()
    {
        
    }

    public void AskQuestion()
    {
        var randomIndex = 0;
        do 
        {
        randomIndex = UnityEngine.Random.Range(0, questions.questionsList.Count);
        }
        while (questions.questionsList[randomIndex].questioned == true);

        questions.currentQuestion = randomIndex;
        questions.questionsList[questions.currentQuestion].questioned = true;
        questionText.text = questions.questionsList[questions.currentQuestion].question;
    }

    private int CountValidQuestions()
    {
        int validQuestions = 0;

        foreach (var q in questions.questionsList)
        {
            if(q.questioned == false)
                validQuestions++;
        }
        Debug.Log("Questions Left" + validQuestions);
        return validQuestions;
    }


}
