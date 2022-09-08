using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        // check for horizontal movement
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        // check for jumping
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }


    }

    void FixedUpdate()
    {
        // Move the character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject c = collider.gameObject;
        if (!c.GetComponent<Interaction>().hasInteracted)
        {
            Debug.Log("Quiz is enabled now - will be attached to player script, will update Q, A and Qs variables for dialog every time");
        }
    }


}
