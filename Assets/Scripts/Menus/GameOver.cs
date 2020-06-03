using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text highScore;
    public Text score;
    
    private void Start()
    {
        if (HighScore.highScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", HighScore.highScore);
            highScore.text = HighScore.highScore.ToString();
        }
        else
            highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        score.text = HighScore.highScore.ToString();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
