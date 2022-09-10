using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public GameObject prompt; //Show interaction prompt
    public bool close = false;

    // Update is called once per frame
    void Update()
    {
        if (close)
        {
            if (Input.GetKeyDown(KeyCode.E))
                {
                DoInteraction();
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Color tmp = prompt.GetComponent<SpriteRenderer>().color;
        tmp.a = 255f; prompt.GetComponent<SpriteRenderer>().color = tmp;
        close = true;           
    } 

    private void OnTriggerExit2D(Collider2D collider)
    {
        Color tmp = prompt.GetComponent<SpriteRenderer>().color;
        tmp.a = 0f; prompt.GetComponent<SpriteRenderer>().color = tmp;
        close = false;
    }

    public void DoInteraction()
    {
        if (door1 != null) 
        { 
            var open = door1.GetComponent<Doors>().isOpen;
            if (!open)
            {
                door1.GetComponent<Doors>().raise();
            }
            else
            {
                door1.GetComponent<Doors>().lower();
            }
        }
        else
        {
            Debug.Log("There is no first door to open");
        }
        if (door2 != null) 
        { 
            var open = door2.GetComponent<Doors>().isOpen;
            if (!open)
            {
                door2.GetComponent<Doors>().raise();
            }
            else
            {
                door2.GetComponent<Doors>().lower();
            }
        }
        else
        {
            Debug.Log("There is no second door to open");
        }
    }
}
