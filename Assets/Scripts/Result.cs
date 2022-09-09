using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Result : MonoBehaviour
{
    public Questions questions;
    public GameObject correctSprite;
    public GameObject incorrectSprite;
    public GlobalVariables scores;
    public Button trueButton;
    public Button falseButton;
    public UnityEvent onNextQuestion;
    public GameObject quizBox;

    // Start is called before the first frame update
    void Start()
    {
        correctSprite.SetActive(false);
        incorrectSprite.SetActive(false);
    }

    public void ShowResults(bool answer)
    {   
        correctSprite.SetActive(questions.questionsList[questions.currentQuestion].isTrue == answer); 
        incorrectSprite.SetActive(questions.questionsList[questions.currentQuestion].isTrue != answer);

        if(questions.questionsList[questions.currentQuestion].isTrue == answer)
        scores.AddScore();

        trueButton.interactable = false;
        falseButton.interactable = false;

        StartCoroutine(ShowResult());
    }

    private IEnumerator ShowResult()
    {
        quizBox.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        correctSprite.SetActive(false);
        incorrectSprite.SetActive(false);
        

        trueButton.interactable = true;
        falseButton.interactable = true;

        onNextQuestion.Invoke();
    }

}
