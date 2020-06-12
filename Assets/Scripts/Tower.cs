using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan, targetEnemy;
    [SerializeField] float attackRange = 40f;
    ParticleSystem projectile;
    private void Start()
    {
        projectile = GetComponentInChildren<ParticleSystem>();
    }
    void Update()
    {
        LookAndShoot();
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

}