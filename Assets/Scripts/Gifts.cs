using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gifts : MonoBehaviour
{

    private static int GemCount; // amount of gems collected
    public Text gemText; // amount as text
    private static int CoinCount; // amount of coins collected
    public Text coinText; // amount as text




    void OnTriggerEnter2D(Collider2D col) // if player touches object
    {
        var gem = col.gameObject.GetComponent<Gem>(); // check if object has gem component
        var coin = col.gameObject.GetComponent<Coin>(); // check if object has coin componenrt
        var treasure = col.gameObject.GetComponent<treasure>(); // check if object has treasure component
        if (gem != null && !gem.Taken) // check if gem is taken
        {
            gem.playSound();
            gem.GetComponent<SpriteRenderer>().enabled = false;
            GemCount += gem.Points; // give player points
            gem.Taken = true; // set object as taken
            gemText.text = GemCount + ""; // update gem count on screen
            Destroy(col.gameObject, gem.gemSound.clip.length);
        }
        else if (coin != null && !coin.Taken) // same but for coins
        {
            coin.playSound();
            coin.GetComponent<SpriteRenderer>().enabled = false; 
            CoinCount += coin.Points;
            coin.Taken = true;
            coinText.text = CoinCount + "";
            Destroy(col.gameObject, coin.coinSound.clip.length);
        }
        else if (treasure != null && !treasure.Taken) { // same but for treasure coins
            col.gameObject.SetActive(false);
            CoinCount += treasure.Points;
            treasure.Taken = true;
            coinText.text = CoinCount + "";
        }
    }

    void OnCollisionEnter2D(Collision2D col) {// remove 5 coins if player hits obstacle
        if (col.gameObject.CompareTag("Obstacle") && !PlayerHealth.isDead && !PlayerHealth.EnemyDeath) {
            CoinCount = (CoinCount >= 5 ? CoinCount - 5 : 0);
            coinText.text = CoinCount + "";
        }
    }
}
