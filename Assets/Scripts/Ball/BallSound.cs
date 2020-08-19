using UnityEngine;

public class BallSound : MonoBehaviour
{
    // Cached
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
    }
}
