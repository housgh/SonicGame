using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Points { get; set; } = 1;
    public bool Taken { get; set; }
    public AudioSource coinSound;


    public void playSound() {
        coinSound.Play();
    }
}
