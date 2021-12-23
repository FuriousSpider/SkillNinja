using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierCollision : MonoBehaviour
{
    public AudioClip[] audioClips;

    AudioSource audioSource;
    int numberOfLives;
    float volume;

    void Start() {
        audioSource = gameObject.AddComponent<AudioSource>();
        numberOfLives = Values.ENEMY_SOLDIER_NUMBER_OF_LIVES;
        volume = PlayerPrefsHandler.GetSoundsVolume();
    }

    void OnTriggerEnter2D(Collider2D col) {
        handleCollision(col);
    }

    void OnTriggerStay2D(Collider2D col) {
        handleCollision(col);
    }

    private void handleCollision(Collider2D col) {
        DaggerHandler daggerHandler = col.gameObject.GetComponent<DaggerHandler>();
        
        if (col.gameObject.tag == Values.TAG_DAGGER && daggerHandler.GetState() == DaggerHandler.State.ACTIVE && daggerHandler.GetTarget() == gameObject) {
            numberOfLives--;
            Destroy(col.gameObject);
            if (numberOfLives <= 0) {
                audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length - 1)], volume * 0.5f);
                Destroy(gameObject, 0.1f);
            }
        }
    }
}
