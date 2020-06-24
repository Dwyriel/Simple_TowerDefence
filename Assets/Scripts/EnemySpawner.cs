using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    AudioSource aS;
    [SerializeField] AudioClip spawnSound;
    [SerializeField] Enemy Enemy;
    [SerializeField] float timeBetweenRespawn = 2f;

    void Start()
    {
        aS = GetComponent<AudioSource>();
        aS.volume = .05f;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenRespawn);
            GameObject newEnemy = Instantiate(Enemy.gameObject, this.transform.position, Quaternion.identity);
            newEnemy.transform.parent = this.transform;
            aS.PlayOneShot(spawnSound);
            FindObjectOfType<EnemiesSpawned>().AddCounter();
            timeBetweenRespawn = Mathf.Clamp(timeBetweenRespawn - 0.01f, .3f, timeBetweenRespawn);
        }
    }
}