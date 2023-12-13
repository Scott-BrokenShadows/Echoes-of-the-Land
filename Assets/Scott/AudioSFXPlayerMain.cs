using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFXPlayerMain : MonoBehaviour
{
    private static AudioSFXPlayerMain instance;

    // Access this instance from other scripts
    public static AudioSFXPlayerMain Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioSFXPlayerMain>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("AudioSFXPlayer");
                    instance = obj.AddComponent<AudioSFXPlayerMain>();
                }
            }
            return instance;
        }
    }

    public AudioClip[] clips;
    public AudioSource thisSource;

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

    // Play a one-shot audio clip
    public void PlayClip(int number)
    {
        if (number >= 0 && number < clips.Length)
        {
            AudioClip playClip = clips[number];
            thisSource.PlayOneShot(playClip);
        }
    }
}
