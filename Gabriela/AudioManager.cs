
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip jumpSFX;
    public AudioClip collectSFX;
    public AudioClip checkpointSFX;

    private void Awake()
    {
        // Check if there is already an AudioManager.
        if (instance == null)
        {
            // Save this AudioManager so we can use it in other scenes.
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Remove this one because we already have an AudioManager.
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Start the background music when the game starts.
        PlayMusic(backgroundMusic);
    }

    // Play the background music again and again.
    public void PlayMusic(AudioClip clip)
    {
        // Check if the audio is ready before playing it.
        if (clip != null && musicSource != null)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    // Play a sound effect when we need it.
    public void PlaySFX(AudioClip clip)
    {
        // Check if the sound is ready first.
        if (clip != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    // Play the jump sound.
    public void PlayJump()
    {
        PlaySFX(jumpSFX);
    }

    // Play the sound when collecting an item.
    public void PlayCollect()
    {
        PlaySFX(collectSFX);
    }

    // Play the sound when reaching a checkpoint.
    public void PlayCheckpoint()
    {
        PlaySFX(checkpointSFX);
    }

    // Change the music volume.
    public void SetMusicVolume(float volume)
    {
        // Check if the music source exists first.
        if (musicSource != null)
        {
            musicSource.volume = volume;
        }
    }

    // Change the sound effects volume.
    public void SetSFXVolume(float volume)
    {
        // Check if the sound source exists first.
        if (sfxSource != null)
        {
            sfxSource.volume = volume;
        }
    }
}
