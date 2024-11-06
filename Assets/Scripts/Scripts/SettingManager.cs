using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Audio Settings")]
    public Slider musicSlider;
    public Slider sfxSlider;
    private float defaultMusicVolume = 0.5f;
    private float defaultSFXVolume = 0.5f;

    [Header("Control Settings")]
    public Dropdown controlDropdown; // Example for switching control schemes

    private void Start()
    {
        LoadSettings();
    }

    // Update Music Volume
    public void SetMusicVolume(float volume)
    {
        AudioListener.volume = volume; // For simplicity; ideally, assign it to a music AudioSource
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    // Update SFX Volume
    public void SetSFXVolume(float volume)
    {
        // Assuming you have an AudioSource for SFX, set its volume here
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    // Update Control Scheme
    public void SetControlScheme(int index)
    {
        // Change controls based on dropdown selection, e.g., 0 for Scheme A, 1 for Scheme B
        PlayerPrefs.SetInt("ControlScheme", index);
    }

    // Load Settings on Start
    private void LoadSettings()
    {
        // Load Music Volume
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", defaultMusicVolume);
        musicSlider.value = musicVolume;
        SetMusicVolume(musicVolume);

        // Load SFX Volume
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", defaultSFXVolume);
        sfxSlider.value = sfxVolume;
        SetSFXVolume(sfxVolume);

        // Load Control Scheme
        int controlScheme = PlayerPrefs.GetInt("ControlScheme", 0);
        controlDropdown.value = controlScheme;
    }

    // Reset Settings to Default
    public void ResetToDefaults()
    {
        // Reset music and SFX to default volumes
        musicSlider.value = defaultMusicVolume;
        sfxSlider.value = defaultSFXVolume;
        SetMusicVolume(defaultMusicVolume);
        SetSFXVolume(defaultSFXVolume);

        // Reset control scheme to the first option
        controlDropdown.value = 0;
        SetControlScheme(0);

        PlayerPrefs.Save();
    }
}
