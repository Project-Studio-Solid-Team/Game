using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2End : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.GetComponent<TardisController2D>().Landing();
        }
    }
}
