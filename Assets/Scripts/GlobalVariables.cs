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
    private int timeScore;

    // Collectables var
    private int fuel = 0; public int fuelMax;
    private int oil = 0; public int oilMax;
    private int ss = 0; public int ssMax;
    private int totalCol = 0;
    private int colMax;
    private AudioSource foundCollectable;

    // Intro screen
    public GameObject LO;

    // Pause menu
    public GameObject pauseMenu;
    private AudioSource pauseSound;  

    // Mission fail
    public GameObject missFail;

    // Mission success
    public GameObject missSuccess;
    public Text scoreFinal;


    // Tardis can launch
    public GameObject playerMessage;
    private bool canLaunch = false;

    // Start is called before the first frame update
    void Start()
    {
        LO.SetActive(true);
        colMax = fuelMax + oilMax + ssMax;
        Time.timeScale = 0;
        currentScore = 0;
        scoreText.text = currentScore.ToString();
        fuelText.text = string.Format("{0}/{1}", fuel, fuelMax);
        oilText.text = string.Format("{0}/{1}", oil, oilMax);
        ssText.text = string.Format("{0}/{1}", ss, ssMax);
        pauseSound = pauseMenu.GetComponent<AudioSource>();
        foundCollectable = this.GetComponent<AudioSource>();
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
                Time.timeScale = 0; missFail.SetActive(true);
            }
        }

        // Pause Logic
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PauseGame();
        }

        if (totalCol == colMax)
        {
            Time.timeScale = 0; totalCol = 0; canLaunch = true;
            playerMessage.SetActive(true);
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
        totalCol++;
        foundCollectable.Play();
    }

    public void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    public void LevelSuccess()
    {
        timeScore = (int) timeLeft;
        currentScore += timeScore;
        scoreFinal.text = string.Format("SCORE: {0}", currentScore);
        missSuccess.SetActive(true);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        pauseSound.Play();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        pauseSound.Stop();
        Time.timeScale = 1;
    }

    public void PlayerMessage()
    {
        playerMessage.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnToMainMenu()
    {
        // Return to main menu here
        // For use with pause menu and end game screen
    }

    public bool CanLaunch()
    {
        return canLaunch;
    }

}
