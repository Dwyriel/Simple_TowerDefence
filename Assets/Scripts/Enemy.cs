using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] AudioClip hitSound, deathSound;
    [SerializeField] int hitPoints = 8;
    [SerializeField] ParticleSystem hitParticle, deathParticle;
    AudioSource aS;
    bool isDestroyed = false;
    private void Start()
    {
        aS = GameObject.FindGameObjectWithTag("AudioPlayer").GetComponent<AudioSource>();
        aS.volume = .1f;
    }
    private void OnParticleCollision(GameObject other)
    {
        hitPoints--;
        if (!isDestroyed && hitPoints <= 0)
        {
            FindObjectOfType<Score>().AddPoint();
            aS.PlayOneShot(deathSound); 
            /*! Could've been done in this way: AudioSource.PlayClipAtPoint(deathSound, this.transform.position);
             * so it'd have reduced the need for a new GameObject and a AudioSource as well as not needing to find
             * the GameObjet through tag everytime a new enemy spawns */
            TriggerDeath(deathParticle);
        } else
        {
            hitParticle.Play();
            aS.PlayOneShot(hitSound);
        }
    }

    public void TriggerDeath(ParticleSystem particle)
    {
        isDestroyed = true;
        ParticleSystem iParticle = Instantiate(particle, this.transform.position + new Vector3(0,6,0), Quaternion.identity);
        Transform iVFXParent = GameObject.FindGameObjectWithTag("destroyer").transform;
        iParticle.gameObject.transform.parent = iVFXParent;
        Destroy(iParticle.gameObject, iParticle.main.duration);
        Destroy(gameObject);
    }
}