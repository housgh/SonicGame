using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
{
    public AudioSource audio;
    public static int currentScene;
    public Rigidbody2D rb;

    IEnumerator OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name.Contains("house")) {
            gameSound.win = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll; //freezes player

            audio.Play(); //plays audio
            yield return new WaitForSeconds(5); // waits for 5s
            currentScene = SceneManager.GetActiveScene().buildIndex; // to load next level
            SceneManager.LoadScene(6); // Load player win Scene
        }
    }
}
