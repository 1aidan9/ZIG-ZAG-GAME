using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundsmanager : MonoBehaviour
{
    public static soundsmanager instance;
    AudioSource source;
    public AudioClip[] audioClips;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void ClickSound()
    {
        source.clip = audioClips[0];
        source.Play();
    }
    public void GameOver()
    {
        source.PlayOneShot(audioClips[1]);

    }

    void Start()
    {
        source = GetComponent<AudioSource>();
    }


}
