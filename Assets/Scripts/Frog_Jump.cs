using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog_Jump : MonoBehaviour
{

    public Animator animator; // jump animator
    private int direction = 1; // object direction

    public AudioClip defaultSound;
    public AudioClip deathSound;
    public AudioSource frogSound;
    private bool dead = false;

    void Start() { // when the game starts
        InvokeRepeating("Jump", 3f, 3f); // repeat function every 3 seconds
    }


    private void Jump() { // jump function
        if (!dead) {
            frogSound.Play();
            if (direction == 1)
            { // check player direction
                GetComponent<SpriteRenderer>().flipX = true; // flip object
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false; // unflip object
            }
            GetComponent<Rigidbody2D>().AddForce(new Vector2(200 * direction, 200)); // add jump force
            animator.SetTrigger("Jump"); // trigger jump animation
            direction = -direction; // change player direction
            GetComponent<Rigidbody2D>().velocity = Vector3.zero; // stop object in place
        }
    }

    public void FrogDeath() {
        dead = true;
        frogSound.clip = deathSound;
        frogSound.Play();
    }
}
