using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelVariables : MonoBehaviour
{
    
    public Text scoreText;
    public Text timerText;
    public Text presentText;
    public Text hitsText;
    public Text multiText;

    //Timer var
    public float timeLeft;
    public bool timerOn = false;

    // Score var
    private int currentScore;
    private int timeScore;

    // Collectables var
    private int hits = 0; public int hitsMax;
    private int present = 0; public int presentMax;
    private float multi = 1.5f; private float multiMax = 1.5f; //private float multiMin = 1.0f;
    public bool ready = false;
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

    // Start is called before the first frame update
    void Start()
    {
        LO.SetActive(true);
        Time.timeScale = 0;
        currentScore = 0;
        scoreText.text = currentScore.ToString();
        presentText.text = string.Format("{0}/{1}", present, presentMax);
        hitsText.text = string.Format("{0}/{1}", hits, hitsMax);
        multiText.text = string.Format("{0}/{1}", multi, multiMax);
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
        if (Input.GetKey(KeyCode.Escape) && Time.timeScale != 0)
        {
            Time.timeScale = 0;
            PauseGame();
        }

        if (present == presentMax)
        {
            Time.timeScale = 0; present = 0;
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
        if(c == "Present")
        {
            present++; presentText.text = string.Format("{0}/{1}", present, presentMax);
        }
        foundCollectable.Play();

        if (present == presentMax)
        {
            ready = true;
        }
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
        currentScore = (int) (currentScore * multi);
        scoreFinal.text = string.Format("SCORE: {0}", currentScore);
        missSuccess.SetActive(true);
        Web Webinteraction = new Web();
        StartCoroutine(Webinteraction.sendScore(PlayerPrefs.GetString("usernamePlayer"), currentScore, 2));
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

    public void SetHits()
    {
        
        hits++; hitsText.text = string.Format("{0}/{1}", hits, hitsMax);
        multi -= 0.05f; multiText.text = string.Format("{0}/{1}", multi, multiMax);
        if (hits = 10)
        {
            missFail.SetActive(true);
        }
    }

}
