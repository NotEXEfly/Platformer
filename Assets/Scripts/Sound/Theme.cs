using UnityEngine;
using UnityEngine.Audio;

public class Theme : MonoBehaviour
{
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    private void OnDisable() => _audioSource.Stop();

    public void Play() => _audioSource.Play();
    public void Stop() => _audioSource.Stop();
}

