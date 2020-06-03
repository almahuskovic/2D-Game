using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool end = false;
    public Transform player;
    
    public void GameOver()
    {
        if (!end)
        {
            end = true;
            PlayerHealthLife.health = 100;
            FindObjectOfType<HealthBar>().SetMaxValue(PlayerHealthLife.health);
            PlayerGoingBack.isGoingBack = false;
            SceneManager.LoadScene("GameOver");
        }
    }
   
}
