using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables2 : MonoBehaviour
{
    public LevelVariables hv;
    private bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (isTriggered == false)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            hv.UpdateCollectables(this.tag.ToString());
            isTriggered = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        this.GetComponent<Collider2D>().enabled = false;
        isTriggered = false;
    }
    
}
