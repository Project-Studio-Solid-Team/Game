using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionData : MonoBehaviour
{
    public Questions questions;
    [SerializeField] private Text _questionText;

    void Start()
    {
        AskQuestion();
    }

    public void AskQuestion()
    {
        var randomIndex = 0;

        randomIndex = UnityEngine.Random.Range(0, questions.questionsList.Count);
        questions.currentQuestion = randomIndex;
        _questionText.text = questions.questionsList[questions.currentQuestion].question;
    }

}
