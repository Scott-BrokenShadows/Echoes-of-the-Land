using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volumeoptions : MonoBehaviour
{
    
    public AudioMixer audioMixer;
    public static float masterVolume { get; private set; }
    public static float musicVolume { get; private set; }
    public static float sfxVolume { get; private set; }

    public Slider sfxSlider;


    
    public void OnMasterSliderValueChange (float value)
    {
        masterVolume = value;
        UpdateMixerVolume("MasterVol", masterVolume);
    }

    public void OnMusicSliderValueChange(float value)
    {
        musicVolume = value;
        UpdateMixerVolume("BGMVol", musicVolume);
    }

    public void OnSFXSliderValueChange(float value)
    {
        sfxVolume = value;
        UpdateMixerVolume("SFXVol", sfxVolume);
        
    }

    public void PlaySFX()
    {
                AudioSFXPlayerMain.Instance.PlayClip(3);
    }

    private void UpdateMixerVolume(string mixer, float volume)
    {
        audioMixer.SetFloat(mixer, Mathf.Log10(volume) * 20);
    }

    
}
