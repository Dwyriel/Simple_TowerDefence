using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int enemiesKilled = 0;
    Text scoreboard;
    private void Start()
    {
        scoreboard = GetComponent<Text>();
        scoreboard.text = enemiesKilled.ToString();
    }

    public void AddPoint()
    {
        enemiesKilled++;
        scoreboard.text = enemiesKilled.ToString();
    }
}
