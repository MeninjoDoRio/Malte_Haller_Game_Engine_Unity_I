using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    public AudioClip[] soundClips;

    // Reference to the AudioSource component
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the game object
        audioSource = GetComponent<AudioSource>();

        // Check if the AudioSource component exists, if not add one
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if there are any audio clips in the array
        if (soundClips.Length > 0)
        {
            // Get a random index from the soundClips array
            int randomIndex = Random.Range(0, soundClips.Length);

            // Play the randomly selected audio clip
            audioSource.clip = soundClips[randomIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No audio clips assigned.");
        }
    }
}
