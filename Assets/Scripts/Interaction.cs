using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    public bool talk; //If true, than this is an NPC with a quiz
    public bool hasInteracted = false;
    public bool close = false;
    public GameObject prompt; //Show interaction prompt
    public GameObject quiz; //The quiz from the NPC
    
    void Update()
    {
        if (!hasInteracted)
        {
            if (close)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    DoInteraction();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!hasInteracted){
            Color tmp = prompt.GetComponent<SpriteRenderer>().color;
            tmp.a = 255f; prompt.GetComponent<SpriteRenderer>().color = tmp;
            close = true;           
        } 
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (!hasInteracted){
            Color tmp = prompt.GetComponent<SpriteRenderer>().color;
            tmp.a = 0f; prompt.GetComponent<SpriteRenderer>().color = tmp;
            close = false;
        } 
    }

    public void DoInteraction()
    {
        quiz.SetActive(true); 
        Color tmp = prompt.GetComponent<SpriteRenderer>().color;
        tmp.a = 0f; prompt.GetComponent<SpriteRenderer>().color = tmp;
        hasInteracted = true;

    }


}
