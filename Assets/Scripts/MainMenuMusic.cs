using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }

    public void StopPlayingMusic()
    {
        audioSource.Stop();
    }
}
