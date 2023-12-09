using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Match3Sounds : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int clip)
    {
        // Play the sound using PlayOneShot
        audioSource.PlayOneShot(audioClips[clip]);
        Debug.Log("Playing sound with clip index: " + clip);
    }
}
