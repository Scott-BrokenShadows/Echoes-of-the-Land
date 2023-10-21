using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audiomanager : MonoBehaviour
{
    public AudioMixer audioMixer; // Reference to your Audio Mixer.
    public AudioMixerGroup musicGroup; // Reference to the music group in your Audio Mixer.

    public AudioSource[] musicSources;

    public float fadeDuration;
    private int currentMusicIndex = 0;
    

    private void Start()
    {
        // Start playing the initial music track.
        
        PlayMusic(currentMusicIndex);
    }

    public void PlayMusic(int musicIndex)
    {
        if (musicIndex >= 0 && musicIndex < musicSources.Length)
        {
            musicSources[musicIndex].Play();
            currentMusicIndex = musicIndex;
        }
    }

    public void CrossfadeMusic(int newMusicIndex)
    {
        StartCoroutine(CrossfadeRoutine(newMusicIndex));
    }

    private IEnumerator CrossfadeRoutine(int newMusicIndex)
    {
        AudioSource fromSource = musicSources[currentMusicIndex];
        AudioSource toSource = musicSources[newMusicIndex];

        // Ensure the target source is playing.
        toSource.volume = 0;
        toSource.Play();

        float startVolume = fromSource.volume;
        

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            fromSource.volume = Mathf.Lerp(startVolume, 0f, t / fadeDuration);
            toSource.volume = Mathf.Lerp(0f, startVolume, t / fadeDuration);
            yield return null;
        }


        // Stop the previous source after the crossfade is complete.
        fromSource.Stop();

        currentMusicIndex = newMusicIndex;
    }
}
