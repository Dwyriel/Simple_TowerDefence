using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesSpawned : MonoBehaviour
{
    int enemiesSpawned = 0;
    Text eSText;
    private void Start()
    {
        eSText = GetComponent<Text>();
        eSText.text = enemiesSpawned.ToString();
    }

    public void AddCounter()
    {
        enemiesSpawned++;
        eSText.text = enemiesSpawned.ToString();
    }
}
