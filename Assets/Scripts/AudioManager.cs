// AudioManager.cs
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip brickHit;
    public AudioClip paddleHit;
    private AudioSource source;

    void Awake()
    {
        instance = this;
        source = gameObject.AddComponent<AudioSource>();
        source.volume = 0.6f;
    }

    public void PlayBrickHit()
    {
        if (brickHit != null)
            source.PlayOneShot(brickHit);
    }

    public void PlayPaddleHit()
    {
        if (paddleHit != null)
            source.PlayOneShot(paddleHit);
    }
}