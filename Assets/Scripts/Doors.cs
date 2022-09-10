using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{

    public bool isOpen = false;
    public float height;

    public void raise()
    {
        Debug.Log("Should be raising door");
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y + (transform.GetComponent<SpriteRenderer>().bounds.size.y * 1.5f), pos.z);
        isOpen = true;
    }

    public void lower()
    {
        Debug.Log("Should be lowering door");
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y - (transform.GetComponent<SpriteRenderer>().bounds.size.y * 1.5f), pos.z);
        isOpen = false;
    }
}
