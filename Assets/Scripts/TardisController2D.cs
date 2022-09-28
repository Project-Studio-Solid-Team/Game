using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TardisController2D : MonoBehaviour
{
    float maxSpeed = 12.0f;
    float rotSpeed = 250f;
    Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        Debug.Log(origin);  
    }

    void Update()
    {
        // Ship rotations
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        // Ship movement
        Vector3 pos = transform.position;
        Vector3 vel = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * vel;
        transform.position = pos;

    }

    // Player Interaction check
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Hazard")
        {
            StartCoroutine(Reset());
        }
    }

    // Return to origin on hazard collision
    IEnumerator Reset(){
        //Disable keyboard on collision and send player back to origin
        this.GetComponent<TrailRenderer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        transform.position = origin;

        //Re-enable keyboard and trail renderer
        yield return new WaitForSeconds(1.5f);
        this.GetComponent<TrailRenderer>().enabled = true;
    }



}
