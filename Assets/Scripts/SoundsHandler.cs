using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsHandler : MonoBehaviour
{
    public AudioClip audioClip;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSounds(float soundsVolume) {
        PlayerPrefsHandler.SetSounds(soundsVolume);

        if (audioSource != null && !audioSource.isPlaying) {
            audioSource.PlayOneShot(audioClip, soundsVolume * 0.5f);
        }
    }
}
