using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hitsToDie = 5;
    bool isDestroyed = false;

    private void OnParticleCollision(GameObject other)
    {
        hitsToDie--;
        if (!isDestroyed && hitsToDie <= 0)
        {
            TriggerDeath();
        }
    }

    private void TriggerDeath()
    {
        isDestroyed = true;
        Destroy(gameObject);
    }
}
