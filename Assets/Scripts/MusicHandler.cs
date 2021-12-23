using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public AudioClip audioClip;

    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying) {
            float volume = PlayerPrefsHandler.GetMusicVolume();
            audioSource.PlayOneShot(audioClip, Values.MUSIC_MAX_VOLUME);
            audioSource.volume = volume;
        }
    }

    public static void UpdateMusic(float musicVolume) {
        PlayerPrefsHandler.SetMusic(musicVolume);
        if (audioSource != null) {
            audioSource.volume = musicVolume;
        }
    }
}
