using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Login : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    public GameObject incorrect;
    public GameObject inputs;
    public GameObject logBut;
    public Button play;
    public Button logout;
    public Web auth = new Web();
    public TextMeshProUGUI welcome;

    public bool validated = true;

    // [SerializeField] public GameObject Username;
    // [SerializeField] public GameObject Password;
   
    // Other code.
    void Start() 
    {
        if (PlayerPrefs.GetString("usernamePlayer", "") != "")
        {
            inputs.SetActive(false);
            logBut.SetActive(false);
            validated = true;
            play.GetComponent<Button>().interactable = true;
            logout.GetComponent<Button>().interactable = true;
            welcome.text = string.Format("Welcome {0}", PlayerPrefs.GetString("usernamePlayer", ""));
        }
    }

    public void UserInput()
    {
        incorrect.SetActive(false);
        PlayerPrefs.SetString("usernamePlayer", username.GetComponent<TMP_InputField>().text);
        // Code that uses the username variable.
        //Debug.Log(username.GetComponent<TMP_InputField>().text);
        // Code that uses the password variable.
        //Debug.Log(password.GetComponent<TMP_InputField>().text);
        AllowPlay();
    }

    public void AllowPlay()
    {
        if (auth.authUserPass(username.GetComponent<TMP_InputField>().text, password.GetComponent<TMP_InputField>().text)){
            Debug.Log("Yes");
            validated = true;
            inputs.SetActive(false);
            logBut.SetActive(false);
            play.GetComponent<Button>().interactable = true;
            logout.GetComponent<Button>().interactable = true;
            welcome.text = string.Format("Welcome {0}", PlayerPrefs.GetString("usernamePlayer", ""));
        //do stuff
        }else {
             incorrect.SetActive(true);
         }
    }

    public void LogOut()
    {
        PlayerPrefs.SetString("usernamePlayer", "");
        inputs.SetActive(true);
        logBut.SetActive(true);
        validated = false;
        play.GetComponent<Button>().interactable = false;
        logout.GetComponent<Button>().interactable = false;
        welcome.text = "";
    }


}
