using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector3 location;
    public GameObject message;
    public int checkNum;

    void Start()
    {
        location = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameObject player = collider.gameObject;
            if (checkNum > player.GetComponent<TardisController2D>().GetCp())
            {
                player.GetComponent<TardisController2D>().SetCp(checkNum);
                player.GetComponent<TardisController2D>().SetOrigin(location);
                StartCoroutine(ShowMessage());
            }
        }
    }

    IEnumerator ShowMessage()
    {
        message.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(2.0f);
        message.GetComponent<SpriteRenderer>().enabled = false;
    }
}
