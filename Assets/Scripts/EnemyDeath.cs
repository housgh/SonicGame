using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class EnemyDeath : MonoBehaviour

{
    public Animator animator;
    
    IEnumerator OnTriggerEnter2D(Collider2D col) { // if enemy collided with object from top (trigger function)
        if (col.gameObject.name.Contains("Sonic")) { // if object is player
            PlayerHealth.EnemyDeath = true; // to avoid decreasing player health
            animator.SetTrigger("Death"); // triggering enemy death animation
            yield return new WaitForSeconds(1); // wait for 1 sec
            gameObject.SetActive(false); // deactivate enemy
            PlayerHealth.EnemyDeath = false; 
        }
    }

    
}
