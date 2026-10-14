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
            // Save this manager so we can use it in other scenes.
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy this one because we only need one manager.
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Start the music only if this is the main AudioManager.
        if (instance == this)
        {
            PlayMusic(backgroundMusic);
        }
    }

    // Play the background music in a loop.
    public void PlayMusic(AudioClip clip)
    {
        // Check if the audio is ready before playing it.
        if (clip == null || musicSource == null) return;

        // Do not play the same music again if it is already playing.
        if (musicSource.clip == clip && musicSource.isPlaying) return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
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

    // Play the jump sound and show a message on the screen.
    [ContextMenu("Test Jump")]
    public void PlayJump()
    {
        PlaySFX(jumpSFX);
        ShowFeedback("[Jump sound]");
    }

    // Play the collect sound so the player knows an item was collected.
    [ContextMenu("Test Collect")]
    public void PlayCollect()
    {
        PlaySFX(collectSFX);
        ShowFeedback("[Calm light collected]");
    }

    // Play the checkpoint sound when the player reaches a checkpoint.
    [ContextMenu("Test Checkpoint")]
    public void PlayCheckpoint()
    {
        PlaySFX(checkpointSFX);
        ShowFeedback("[Checkpoint activated]");
    }

    // Show a subtitle and a visual effect to give more feedback.
    private void ShowFeedback(string message)
    {
        // Check if the UI is available in the current scene.
        if (UIManager.instance != null)
        {
            UIManager.instance.ShowSubtitle(message, 1.5f);
            UIManager.instance.TriggerVisualFeedback();
        }
    }

    // Change the music volume, from 0 to 1.
    public void SetMusicVolume(float volume)
    {
        // Keep the volume between 0 and 1.
        if (musicSource != null)
        {
            musicSource.volume = Mathf.Clamp01(volume);
        }
    }

    // Change the sound effects volume, from 0 to 1.
    public void SetSFXVolume(float volume)
    {
        // Keep the volume in the correct range.
        if (sfxSource != null)
        {
            sfxSource.volume = Mathf.Clamp01(volume);
        }
    }
}
