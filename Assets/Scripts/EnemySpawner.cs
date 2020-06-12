using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy Enemy;
    [SerializeField] float timeBetweenRespawn = 2f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenRespawn);
            GameObject newEnemy = Instantiate(Enemy.gameObject, this.transform.position, Quaternion.identity);
            newEnemy.transform.parent = this.transform;
        }
    }
    void Update()
    {

    }
}
