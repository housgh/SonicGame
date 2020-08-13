using UnityEngine;

public class Gem : MonoBehaviour
{
    public int Points { get; set; } = 1;
    public bool Taken { get; set; }
    public AudioSource gemSound;


    public void playSound()
    {
        gemSound.Play();
    }
}
