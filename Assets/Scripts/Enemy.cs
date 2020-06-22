using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hitPoints = 8;
    [SerializeField] ParticleSystem hitParticle, deathParticle;
    bool isDestroyed = false;

    private void OnParticleCollision(GameObject other)
    {
        if (!isDestroyed && hitPoints <= 0)
        {
            TriggerDeath();
        } else
        {
            hitParticle.Play();
            hitPoints--;
        }
    }

    private void TriggerDeath()
    {
        isDestroyed = true;
        Instantiate(deathParticle, this.transform.position + new Vector3(0,6,0), Quaternion.identity);
        Destroy(gameObject);
    }
}