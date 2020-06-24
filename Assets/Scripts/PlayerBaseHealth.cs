using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBaseHealth : MonoBehaviour
{
    [SerializeField] AudioClip dmgSound;
    [SerializeField] int playerHP = 20;
    AudioSource aS;
    Text hp;
    int halfDead, nearDeath;
    bool isYellow = false, isRed = false;

    void Start()
    {
        aS = GetComponent<AudioSource>();
        aS.volume = .2f;
        halfDead = playerHP / 2;
        nearDeath = playerHP / 4;
        hp = GetComponent<Text>();
        hp.color = Color.green;
        hp.text = playerHP.ToString();
    }

    public void ReduceHP()
    {
        playerHP--;
        hp.text = playerHP.ToString();
        aS.PlayOneShot(dmgSound);
        if (!isRed && playerHP <= nearDeath)
        {
            print("red");
            isRed = true;
            hp.color = Color.red;
        }
        else if (!isYellow && playerHP <= halfDead)
        {
            isYellow = true;
            print("yellow");
            hp.color = Color.yellow;
        }

        if (playerHP <= 0)
        {
            //TODO reload scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
