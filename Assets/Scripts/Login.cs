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
    public Web auth = new Web();

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
            play.GetComponent<Button>().interactable = true;
        //do stuff
        }else {
             incorrect.SetActive(true);
         }
    }


}
