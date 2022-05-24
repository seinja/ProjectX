using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer Instance { get; private set; }

    private AudioSource _audioSource;

    [SerializeField] private AudioClip _dialogOpen;
    [SerializeField] private AudioClip _dialogClose;
    [SerializeField] private AudioClip _dialogType;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayDialogShow()
    {
        _audioSource.PlayOneShot(_dialogOpen);
    }

    public void PlayDialogHide()
    {
        _audioSource.PlayOneShot(_dialogClose);
    }

    public void PlayDialogType()
    {
        _audioSource.PlayOneShot(_dialogType);
    }
}
