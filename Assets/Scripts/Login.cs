using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Login : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    public Button play;

    public bool validated = true;

    // [SerializeField] public GameObject Username;
    // [SerializeField] public GameObject Password;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    // Other code.

    public void UserInput()
    {
        string user = username.GetComponent<TMP_InputField>().text;
        // Code that uses the username variable.
        Debug.Log(user);
    }

    public void PassInput ()
    {
        string pass = password.GetComponent<TMP_InputField>().text;
        // Code that uses the password variable.
        Debug.Log(pass);
        AllowPlay();
    }

    public void AllowPlay()
    {
        if (validated) {
            play.interactable = true;
        }
        
    }


}
