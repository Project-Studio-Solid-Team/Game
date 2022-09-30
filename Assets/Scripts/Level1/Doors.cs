using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{

    public bool isOpen = false;
    public float height;
    public float speed = 2.0f;

    public void raise()
    {
        Vector2 pos = transform.position;
        transform.position = new Vector2(pos.x, pos.y + (transform.GetComponent<SpriteRenderer>().bounds.size.y * 1.5f));
        isOpen = true;
    }

    public void lower()
    {
        Vector2 pos = transform.position;
        transform.position = new Vector2(pos.x, pos.y - (transform.GetComponent<SpriteRenderer>().bounds.size.y * 1.5f));
        isOpen = false;
    }
}
