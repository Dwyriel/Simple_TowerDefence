using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan, targetEnemy;

    void Update()
    {
        lootAtEnemy();
    }

    void lootAtEnemy()
    {
        objectToPan.LookAt(targetEnemy);
    }

}