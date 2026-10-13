using UnityEngine;

/// <summary>
/// Manages background music and sound effects for the game.
/// Provides accessibility volume controls.
/// </summary>
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
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(backgroundMusic);
    }

    // Plays background music on loop
    public void PlayMusic(AudioClip clip)
    {
        if (clip != null && musicSource != null)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    // Plays a one-shot sound effect
    public void PlaySFX(AudioClip clip)
    {
        if (clip != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    // Specific methods for game actions
    public void PlayJump()
    {
        PlaySFX(jumpSFX);
    }

    public void PlayCollect()
    {
        PlaySFX(collectSFX);
    }

    public void PlayCheckpoint()
    {
        PlaySFX(checkpointSFX);
    }

    // Accessibility feature: Adjust music volume dynamically
    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;
        }
    }

    // Accessibility feature: Adjust SFX volume dynamically
    public void SetSFXVolume(float volume)
    {
        if (sfxSource != null)
        {
            sfxSource.volume = volume;
        }
    }
}