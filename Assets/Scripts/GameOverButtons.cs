using UnityEngine;
using UnityEngine.SceneManagement;


/*
    This script closes is unfinished and unused at a time where I
    was probably planning on making a script for each button.
 
 */


public class GameOverButtons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void HighScores()
    {
        
    }
    public void HighScoresBack()
    {
        
    }
}
