using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalVariables : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;
    public Text fuelText;
    public Text oilText;
    public Text ssText;

    //Timer var
    public float timeLeft;
    public bool timerOn = false;

    // Score var
    private int currentScore;

    // Collectables var
    private int fuel = 0; public int fuelMax;
    private int oil = 0; public int oilMax;
    private int ss = 0; public int ssMax;

    // Intro screen
    public GameObject LO;

    // Pause menu
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        LO.SetActive(true);
        Time.timeScale = 0;
        currentScore = 0;
        scoreText.text = currentScore.ToString();
        fuelText.text = string.Format("{0}/{1}", fuel, fuelMax);
        oilText.text = string.Format("{0}/{1}", oil, oilMax);
        ssText.text = string.Format("{0}/{1}", ss, ssMax);
    }

    public void LevelPlay()
    {
        LO.SetActive(false);
        Time.timeScale = 1;
        timerOn = true;
    }

    void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else{
                timeLeft = 0;
                timerOn = false;
                // End level logic here > fail, time's up
            }
        }

        // Pause Logic
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PauseGame();
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddScore()
    {
        currentScore += 100;
        scoreText.text = currentScore.ToString();
    }

    public void UpdateCollectables(string c)
    {
        if(c == "Fuel")
        {
            fuel++; fuelText.text = string.Format("{0}/{1}", fuel, fuelMax);
        }
        if(c == "Oil")
        {
            oil++; oilText.text = string.Format("{0}/{1}", oil, oilMax);
        }
        if(c == "SS")
        {
            ss++; ssText.text = string.Format("{0}/{1}", ss, ssMax);
        }
    }

    public void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    public void LevelFail()
    {
        // Level fail screen init, show options to retry or return to main
    }

    public void LevelSuccess()
    {
        // Level success init, show option to retry or return to main
        // Post score to DB
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnToMainMenu()
    {
        // Return to main menu here
        // For use with pause menu and end game screen
    }

    public void AddFinalScore()
    {
        // Need to add this depending on time
    }

}
