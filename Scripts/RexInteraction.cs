using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RexInteraction : MonoBehaviour
{
    public AudioClip coinSound; 
    public AudioClip speedBoostSound; 
    public AudioClip roarSound;
    public AudioClip hurtSound;
    private AudioSource audioSource;
    private TrailRenderer trailRenderer;
    private Animator Rex_Animator;

    // Start is called before the first frame update
    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        Rex_Animator = GetComponent<Animator>();
        trailRenderer.enabled = false; // Initially disable the trail
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) // Safety check
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(coinSound);
            ParticleSystem coinParticles = other.GetComponent<ParticleSystem>();
            if (coinParticles)
            {
                coinParticles.Play(); // Start playing the particle effect
                coinParticles.transform.SetParent(null);
                Destroy(coinParticles.gameObject, coinParticles.main.duration);
            }
        }
        if (other.gameObject.CompareTag("SpeedBoost"))
        {
            audioSource.PlayOneShot(speedBoostSound);
            StartCoroutine(ActivateSpeedTrail());
        }

        if (other.CompareTag("Mutant"))
        {
            audioSource.PlayOneShot(roarSound);
            Animator Mutant_Animator = other.GetComponent<Animator>();
            if (Mutant_Animator != null)
            {
                // Activating the trigger to play the jump animation
                Mutant_Animator.SetTrigger("MutantJump");
            }
            if (Rex_Animator != null)
            {
                Rex_Animator.SetTrigger("Fall");
                audioSource.PlayOneShot(hurtSound);
            }
            ScoreManager.instance.DeductPoints(5);
        }
    }

    IEnumerator ActivateSpeedTrail()
    {
        trailRenderer.enabled = true; // Enable the trail
        yield return new WaitForSeconds(5); // Wait for the duration of the speed boost
        trailRenderer.enabled = false;
    }
}

