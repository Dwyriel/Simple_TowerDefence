using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 40f;
    ParticleSystem projectile;
    Transform targetEnemy;
    Waypoint baseWaypoint;
    private void Start()
    {
        projectile = GetComponentInChildren<ParticleSystem>();
    }
    void Update()
    {
        SetTargetEnemy();
        LookAndShoot();
    }

    private void SetTargetEnemy()
    {
        Enemy[] sceneEnemies = FindObjectsOfType<Enemy>();
        if (sceneEnemies.Length == 0)
        {
            return;
        }
        Transform closestEnemy = sceneEnemies[0].transform;
        foreach (Enemy testEnemy in sceneEnemies)
        {
            closestEnemy = getClosest(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    Transform getClosest(Transform transform1, Transform transform2)
    {
        if (Vector3.Distance(this.transform.position, transform1.transform.position) > Vector3.Distance(this.transform.position, transform2.transform.position))
        {
            transform1 = transform2;
        }
        return transform1;
    }

    void LookAndShoot()
    {
        bool inRange = false;
        if (targetEnemy != null)
        {
            inRange = Vector3.Distance(this.transform.position, targetEnemy.transform.position) <= attackRange;
        }
        if (inRange)
        {
            objectToPan.LookAt(targetEnemy);
            if (!projectile.isPlaying)
            {
                projectile.Play();
            }
        }
        else if (!inRange && projectile.isPlaying)
        {
            projectile.Stop();
        }
    }

    public void SetBaseWaypoint(Waypoint waypoint)
    {
        this.baseWaypoint = waypoint;
    }
    public Waypoint GetBaseWaypoint()
    {
        return this.baseWaypoint;
    }
}