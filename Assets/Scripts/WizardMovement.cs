using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMovement : MonoBehaviour
{
    public Animator animator;
    public Transform trans;
    public float lastPos; 
    public Vector2 start;
    public bool dir;
    public SpriteRenderer r;


    void Start() {
        start = trans.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float a = Mathf.PingPong(Time.time*2, 10);
        if ((a - lastPos > 0 && dir) || (a - lastPos < 0 && !dir))
        { // check if the direction of enemy has changed
            r.flipX = !r.flipX; //flip enemy
            dir = !dir; //change direction
        }
        trans.position = new Vector2(start.x - a, start.y);
        lastPos = a; // change last position
    }
    

    IEnumerator OnTriggerEnter2D(Collider2D col)
    { // if enemy collided with object from top (trigger function)
        if (col.gameObject.name.Contains("Sonic"))
        { // if object is player
            PlayerHealth.EnemyDeath = true; // to avoid decreasing player health
            animator.SetTrigger("Death"); // triggering enemy death animation
            yield return new WaitForSeconds(2); // wait for 1 sec
            gameObject.SetActive(false); // deactivate enemy
            PlayerHealth.EnemyDeath = false;
        }
    }
}
