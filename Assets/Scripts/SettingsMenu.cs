using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer _audioMixer;
    [SerializeField]
    private Dropdown _resolutionDropdown;
    [SerializeField]
    private Dropdown _qualityDropdown;
    [SerializeField]
    private Toggle _fullscreenToggle;
    [SerializeField]
    private Slider _volumeSlider;

    private Resolution[] _resolutions;
    private int _currentResolutionIndex = 0;

    private void Start()
    {
        InitResolutions();
        LoadSettings();
    }

    public void InitResolutions()
    {
        Debug.Log("InitResolutions");
        _resolutions = Screen.resolutions;
        _resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        
        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + " x " + _resolutions[i].height;
            options.Add(option);

            if (_resolutions[i].height == Screen.currentResolution.height &&
                _resolutions[i].width == Screen.currentResolution.width)
            {
                _currentResolutionIndex = i;
            }
        }

        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resIndex)
    {
        Resolution resolution = _resolutions[resIndex];
        PlayerPrefs.SetInt("settingsResolution", resIndex);
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qIndex)
    {
        PlayerPrefs.SetInt("settingsQuality", qIndex);
        QualitySettings.SetQualityLevel(qIndex);
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("settingsVolume", volume);
        _audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    private void LoadSettings()
    {
        if (PlayerPrefs.HasKey("settingsVolume"))
            _volumeSlider.value = PlayerPrefs.GetFloat("settingsVolume");

        if (PlayerPrefs.HasKey("settingsQuality"))
            _qualityDropdown.value = PlayerPrefs.GetInt("settingsQuality");

        if (PlayerPrefs.HasKey("settingsResolution"))
            _resolutionDropdown.value = PlayerPrefs.GetInt("settingsResolution");
        else
            _resolutionDropdown.value = _currentResolutionIndex;

        _fullscreenToggle.isOn = Screen.fullScreen;
    }
}
