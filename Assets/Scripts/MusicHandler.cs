using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public static bool isMusicOn;
    public AudioClip audioClip;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        isMusicOn = PlayerPrefsHandler.IsMusicPlaying();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying) {
            audioSource.PlayOneShot(audioClip, 0.3f);
        }
        
        if (!isMusicOn) {
            audioSource.volume = 0.0f;
        } else if (isMusicOn) {
            audioSource.volume = 0.3f;
        }
    }

    public static void switchMusic() {
        isMusicOn = !isMusicOn;
    }
}
