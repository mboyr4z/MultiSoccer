using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    public string name;

    public AudioClip clip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void Play()
    {
        audioSource.PlayOneShot(clip);
    }

    public void Stop()
    {
        audioSource.Stop();
    }

}
