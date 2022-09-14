using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TardisController2D : MonoBehaviour
{
    float maxSpeed = 12.0f;
    float rotSpeed = 250f;

    // Start is called before the first frame update
    void Start()
    {
        //  
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



}
