using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;
    public Toggle FPSToggle;

    Resolution[] resolutions;

    private void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.GetFloat("volume", Main.volume);
            audioMixer.SetFloat("volume", Main.volume);
        }

        if (PlayerPrefs.HasKey("qualityIndex"))
        {
            PlayerPrefs.GetInt("qualityIndex", Main.qualityIndex);
            QualitySettings.SetQualityLevel(Main.qualityIndex);
        }

        if (PlayerPrefs.HasKey("isFullscreen"))
        {
            Main.isFullscreen = PlayerPrefs.GetInt("isFullscreen") == 1 ? true : false;
            Screen.fullScreen = Main.isFullscreen;
        }

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        Main.volume = volume;
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        Main.qualityIndex = qualityIndex;
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("qualityIndex", Main.qualityIndex);

    }

    public void SetFullscreen(bool isFullscreen)
    {
        Main.isFullscreen = isFullscreen;
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("isFullscreen", Main.isFullscreen ? 1 : 0);
    }

    public void SetFPS()
    {
        Main.IsFPSShow = !Main.IsFPSShow;
        //FPSToggle.isOn = Main.IsFPSShow;
    }
}
