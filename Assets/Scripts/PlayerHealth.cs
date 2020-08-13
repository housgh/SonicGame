using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    
    public Rigidbody2D rb; //body of player  
    public Image image; //health amount image  
    public float health = 1f; //player health   
    public Animator animator; //death animator
    public Animator transition; // transition animator
    public Animator gameOver; // show gameOver Image
    public static bool isDead; //check if player
    public static bool EnemyDeath = false; // to avoid taking damage from dead enemy
    public CinemachineVirtualCamera camera; // virtual camera
    public AudioSource audio;
    public GameObject coinPrefab;
    public static int currentScene;


    IEnumerator OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.CompareTag("Obstacle") && health !=0 && !EnemyDeath) { //if player hit an obstacle
            float sign = GetComponent<Transform>().position.x - c.gameObject.transform.position.x; // get position difference between player and obstacle to see in which direction he hit it
            float dir = sign / Mathf.Abs(sign); // change the differencethe player to either 1 or -1
            rb.AddForce(new Vector2(300 * sign, 300)); // add force according to sign
            health -= 0.125f; // decrease player health
            image.fillAmount = health; // change health amount (Image)
            audio.Play(); // play coins audio
           // removeCoins();
        }

        if (health == 0 && !isDead) { //if player is dead
            gameSound.isOver = true;
            isDead = true; // set player as dead
            camera.Follow = null;// freeze camera
            animator.SetTrigger("Dead"); // trigger death animation
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;//freeze rotation of player
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;// freeze position of player
            rb.gameObject.GetComponent<BoxCollider2D>().isTrigger = true; // so that the player
            rb.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;// doesnt hit the floor
            yield return new WaitForSeconds(1); // wait for 1 sec
            transition.SetTrigger("End"); // Trigger fade in animation
            yield return new WaitForSeconds(2);
            gameOver.SetTrigger("gameOver");
            yield return new WaitForSeconds(4);
            currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManagement.GameOver();
        }
    }
    void OnTriggerEnter2D(Collider2D c) {
        var cherry = c.gameObject.GetComponent<Cherry>(); // check if the object has the cherry component(if yes then the object is a cherry)
        if (cherry != null && cherry.Taken == false && health!= 1 && !isDead) { // check if cherry and if cherry was taken and if player is dead
            health += cherry.Points; // add health to player
            image.fillAmount = health; // change health amount (Image)
            c.gameObject.SetActive(false); // hide the cherry
        }
    }

    
}
