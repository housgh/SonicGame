using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public CharacterController2D controller; // player controller
    public Animator animator; // player animator
    public AudioSource source;
    public AudioSource rollSound;
    public float runSpeed = 80f; // player speed
    public float playerMovement = 0f; // player velocity
    public bool jump; // if jump input is pressed
    public bool crouch ; // if crouch (roll) input is pressed
    
    void Update()
    {
        playerMovement = Input.GetAxisRaw("Horizontal") * runSpeed; //returns 1 for right arrow key/d, -1 for left arrow key/a

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) // check if shift is pressed
        {
            runSpeed = 150f; // increase speed
            animator.SetBool("run", true); // start run animation
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)) { // check if shift is released
            runSpeed = 80f; // decrease speed
            animator.SetBool("run", false);// stop run animation
        }

        if (controller.m_Grounded) { // if player is on ground
            animator.SetFloat("Speed", Mathf.Abs(playerMovement)); // activate movement animation
        }

        if (Input.GetButtonDown("Jump") && !crouch && controller.m_Grounded) { // space is clicked and the player is on ground and not crouching
            jump = true; // jump
            animator.SetTrigger("jump"); // trigger jumo animation
            source.Play(); // play jump sound
        }

        if (Input.GetButtonDown("Crouch") && playerMovement != 0) // crouch (s or down) is clicked
        {
            rollSound.Play();
            crouch = true; // crouch (decrease player hight)
            runSpeed = 120f; // increase speed
        }
        else if (Input.GetButtonUp("Crouch") || playerMovement == 0) { // crouch is unclicked
            rollSound.Stop();
            crouch = false; // stop crouching
            runSpeed = 80f; // return speed to normal
        }
    }


    void FixedUpdate() {
       // Debug.Log(crouch);
        controller.Move(playerMovement * Time.fixedDeltaTime, crouch, jump); // move player / crouch if its true/ jump if its true
        jump = false; // set the jump false to stop continuous jumping
    }

    public void onCrouching(bool isCrouching) {
        animator.SetBool("crouch", isCrouching); //start crouching animation if player is crouching
    }
}
