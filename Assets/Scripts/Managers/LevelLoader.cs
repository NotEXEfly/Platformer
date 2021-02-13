using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator Transition;
    public float transitionTime = 1f;

    [SerializeField]
    private AudioMixer _audioMixer;


    private bool _loadStarted = false;

    private void Update()
    {
        SmoothFadeAudio();
    }

    public void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(LoadLevel(sceneIndex));
    }

    public void LoadMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void RestartScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    private void SmoothFadeAudio()
    {
        _audioMixer.GetFloat("volume", out float currentVolume);
        // volume down
        if (_loadStarted)
        {
            _audioMixer.SetFloat("volume", Mathf.Lerp(currentVolume, -60f, 0.01f));
        }
        // volume up
        else
        {
            float targetVol = Mathf.Lerp(currentVolume, PlayerPrefs.GetFloat("settingsVolume"), 0.01f);

            if ((targetVol - currentVolume) > 0.001f)
                _audioMixer.SetFloat("volume", targetVol);    
        }
    }

    private IEnumerator LoadLevel(int sceneIndex)
    {
        if (SceneManager.sceneCountInBuildSettings < sceneIndex + 1)
        {
            sceneIndex = 0;
        }

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        Transition.SetTrigger("Start");
        _loadStarted = true;

        while (!operation.isDone)
        {
            yield return null;
        }

        //yield return new WaitForSeconds(transitionTime);

        //SceneManager.LoadScene(sceneIndex);
    }
    
}
