using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    private AudioSource jumpSound;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;

    void Start()
    {
        jumpSound = this.GetComponent<AudioSource>();
    }

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
            jumpSound.Play();
        }


    }

    void FixedUpdate()
    {
        // Move the character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

    }

}
