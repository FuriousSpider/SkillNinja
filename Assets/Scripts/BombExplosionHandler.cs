using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosionHandler : MonoBehaviour
{
    public AudioClip[] audioClips;

    TimeManager timeManager;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        timeManager = new TimeManager(Values.ENEMY_BOMB_EXPLOSION_ACTIVE_TIME, Values.ENEMY_BOMB_EXPLOSION_ACTIVE_TIME);
        timeManager.Start();
        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length - 1)], 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeManager.HasIntervalPassed()) {
            Destroy(gameObject);
        }
    }
}
