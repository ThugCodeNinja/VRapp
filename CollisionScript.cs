using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollisionScript : MonoBehaviour
{
    public ParticleSystem collisionParticles;
    public AudioClip collisionSound;

    private void OnCollisionEnter(Collision collision)
    {
        // Play collision particles
        if (collisionParticles != null)
        {
            ParticleSystem particles = Instantiate(collisionParticles, transform.position, Quaternion.identity);
            particles.Play();
            Destroy(particles.gameObject, particles.main.duration);
        }

        // Play collision sound
        if (collisionSound != null)
        {
            AudioSource.PlayClipAtPoint(collisionSound, transform.position);
        }

        // Destroy the object
        Destroy(gameObject);
    }
}

