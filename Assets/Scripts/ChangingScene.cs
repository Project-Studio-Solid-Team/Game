using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ChangingScene : MonoBehaviour
{
    // public Button Settings;
    // Start is called before the first frame update
    void Start()
    {
        // if (Settings.interactable == false) {
        //     Settings.interactable = true;
        //     SceneManager.LoadScene (sceneName:"Settings");
        // }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchSettingsScene()
    {
        SceneManager.LoadScene (sceneName:"Settings");
    }

    public void SwitchPlayScene()
    {
        SceneManager.LoadScene (sceneName:"Play");
    }

    public void SwitchLeadereboardScene()
    {
        SceneManager.LoadScene (sceneName:"Leaderboard");
    }

    public void SwitchBack()
    {
        SceneManager.LoadScene (sceneName:"MainMenu");
    }
}
