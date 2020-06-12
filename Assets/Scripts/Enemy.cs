using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hitPoints = 8;
    bool isDestroyed = false;

    private void OnParticleCollision(GameObject other)
    {
        if (!isDestroyed && hitPoints <= 0)
        {
            TriggerDeath();
        } else
        {
            hitPoints--;
        }
    }

    private void TriggerDeath()
    {
        isDestroyed = true;
        Destroy(gameObject);
    }
}