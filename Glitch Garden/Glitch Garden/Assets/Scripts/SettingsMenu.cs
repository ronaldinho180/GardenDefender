using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public TMP_Dropdown dropDown;
    public TMP_Dropdown dropDown2;
    public TMP_Dropdown dropDown3;
    public AudioSource audioSource;
    [SerializeField] public float volume = 0.1f;
    [SerializeField] public PlayerPrefsController controller;
    private Resolution[] screenResolutions;

	// Use this for initialization
	void Start ()
	{
	    PopulateList();
	}

    void Update()
    {
        SetVolume(volume);
        SetDifficulty(dropDown3.value);
    }

    void PopulateList()
    {
        dropDown.ClearOptions();
        dropDown2.ClearOptions();
        dropDown3.ClearOptions();

        screenResolutions = Screen.resolutions;
        List<string> resolutions = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < screenResolutions.Length; i++)
        {
            resolutions.Add(screenResolutions[i].ToString());
            if (screenResolutions[i].width == Screen.currentResolution.width && screenResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        List<string> graphicsQuality = new List<string>() {"ULTRA", "VERY HIGH", "HIGH", "MEDIUM", "LOW", "VERY LOW"};

        List<string> difficultyMode = new List<string>() {"EASY", "MEDIUM", "HARD"};

        dropDown.AddOptions(resolutions);
        dropDown.value = currentResolutionIndex;
        dropDown.RefreshShownValue();

        dropDown2.AddOptions(graphicsQuality);
        dropDown3.AddOptions(difficultyMode);
    }

    public void SetVolume(float volumeSlider)
    {
        volume = volumeSlider;
        audioSource.volume = volume;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = screenResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetDifficulty(int diff)
    {
        controller.SetDifficulty(diff);
    }

}
