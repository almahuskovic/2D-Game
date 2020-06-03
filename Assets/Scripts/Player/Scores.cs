using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public Text healthScore;
    public Text distanceScore;
    public Transform player;
    void Update()
    {
        healthScore.text = PlayerHealthLife.health.ToString();
        distanceScore.text = Math.Round(player.transform.position.x).ToString();
        if(int.TryParse(distanceScore.text,out int check))
            HighScore.highScore = int.Parse(distanceScore.text);
    }
}
