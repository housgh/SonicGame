using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement :  MonoBehaviour {

    
    
    public void Play() { //Main Menu Play Button
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 2);
    }

    public void Levels() { // Main Menu Level Page
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }

    public static void GameOver() { //When player loses
        SceneManager.LoadScene(5);
    }
    public void MainMenu() { // Leads to Main Menu
        SceneManager.LoadScene(0);
    }

    public void playAgain() { // to replay lost scene
        SceneManager.LoadScene(PlayerHealth.currentScene);
    }

    public void exit() { // quits game (x)
        Application.Quit();
    }

    public void NextLevel() { //loads next level
        if (PlayerWin.currentScene == 4) {
            MainMenu();
            return;
        }
        SceneManager.LoadScene(PlayerWin.currentScene + 1);
    }
    public void FirstLevel() { // loads first level
        SceneManager.LoadScene(2);
    }
    public void SecondLevel()
    {
        SceneManager.LoadScene(3);
    }
    public void ThirdLevel()
    {
        SceneManager.LoadScene(4);
    }
}
