using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveCheck : MonoBehaviour
{
    public LevelVariables lv;
    public GameObject ready;
    public GameObject notReady;
    public GameObject gate;
    private Animator gateAnim;
    private bool locked = true, near = false;

    void Start()
    {
        gateAnim = gate.GetComponent<Animator>();
    }

    void Update()
    {
        if (!locked && near)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(OpenGate());
            }
        }

        if (lv.ready)
        {
            locked = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && lv.GetComponent<LevelVariables>().ready)
        {
            ready.GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("Yep");
            near = true;

        }
        else
        {
            notReady.GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("Nope");
            near = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        ready.GetComponent<SpriteRenderer>().enabled = false;
        notReady.GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("Hiding prompt");
        near = false;
    }

    IEnumerator OpenGate()
    {
        gateAnim.SetTrigger("Open");
        ready.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        gate.SetActive(false);
    }

}
