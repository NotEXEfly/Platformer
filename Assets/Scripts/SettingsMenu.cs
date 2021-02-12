using System.Collections;
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

    private Resolution[] _resolutions;

    private void Start()
    {
        InitResolutions();
    }

    public void InitResolutions()
    {
        _resolutions = Screen.resolutions;
        _resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + " x " + _resolutions[i].height;
            options.Add(option);

            if (_resolutions[i].height == Screen.currentResolution.height &&
                _resolutions[i].width == Screen.currentResolution.width)
            {
                currentResolutionIndex = i;
            }

            Debug.Log(option);
        }

        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.value = currentResolutionIndex;
        _resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resIndex)
    {
        Resolution resolution = _resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qIndex)
    {
        QualitySettings.SetQualityLevel(qIndex);
    }

    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
