using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine; 
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // Reference to the AudioMixer
    public AudioMixer audioMixer;

    // Reference to the UI Sliders
    public Slider generalVolumeSlider;
    public Slider vfxVolumeSlider;
    public Slider musicVolumeSlider;

    void Start()
    {
        // Initialize sliders with current audio levels
        float volume;
        if (audioMixer.GetFloat("GeneralVolume", out volume))
            generalVolumeSlider.value = Mathf.Pow(10, volume / 20);  // Convert from decibels to linear

        if (audioMixer.GetFloat("VFXVolume", out volume))
            vfxVolumeSlider.value = Mathf.Pow(10, volume / 20);  // Convert from decibels to linear

        if (audioMixer.GetFloat("MusicVolume", out volume))
            musicVolumeSlider.value = Mathf.Pow(10, volume / 20);  // Convert from decibels to linear

        // Add listener to handle slider value changes
        generalVolumeSlider.onValueChanged.AddListener(SetGeneralVolume);
        vfxVolumeSlider.onValueChanged.AddListener(SetVFXVolume);
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    // Methods to set the volumes
    public void SetGeneralVolume(float volume)
    {
        Debug.Log($"Setting General Volume to {volume}");
        audioMixer.SetFloat("GeneralVolume", Mathf.Log10(volume) * 20);  // Convert from linear to decibels
    }

    public void SetVFXVolume(float volume)
    {
        Debug.Log($"Setting VFX Volume to {volume}");
        audioMixer.SetFloat("VFXVolume", Mathf.Log10(volume) * 20);  // Convert from linear to decibels
    }

    public void SetMusicVolume(float volume)
    {
        Debug.Log($"Setting Music Volume to {volume}");
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);  // Convert from linear to decibels
    }
}