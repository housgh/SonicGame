using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSound : MonoBehaviour
{

    public AudioSource ThemeSong;
    public AudioSource gameOver;
    public static bool isOver;
    public static bool win;


    void Update()
    {
        if (isOver)
        {
            ThemeSong.Stop(); // Stops Theme Song
            gameOver.Play(); //Plays game over sound
            isOver = false;
        }
        else if (win) {
            ThemeSong.Stop();
            win = false;
        }
    }
}
