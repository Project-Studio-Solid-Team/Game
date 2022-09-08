using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    public bool talk; //If true, than this is an NPC with a quiz
    public bool hasInteracted = false;
    public GameObject prompt; //Show interaction prompt
    public GameObject message; //The quiz from the NPC
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!hasInteracted){
            Color tmp = prompt.GetComponent<SpriteRenderer>().color;
            tmp.a = 255f; prompt.GetComponent<SpriteRenderer>().color = tmp;
        } 
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (!hasInteracted){
            Color tmp = prompt.GetComponent<SpriteRenderer>().color;
            tmp.a = 0f; prompt.GetComponent<SpriteRenderer>().color = tmp;
        } 
    }

    public void DoInteraction()
    {
        //
    }


}
