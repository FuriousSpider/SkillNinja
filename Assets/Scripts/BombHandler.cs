using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHandler : MonoBehaviour
{

    public GameObject explosionObject;
    public AudioClip fuseAC;
    public AudioClip[] defuseAC;

    TimeManager timeManager;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        timeManager = new TimeManager(Values.ENEMY_BOMB_ACTIVE_TIME, Values.ENEMY_BOMB_ACTIVE_TIME);
        timeManager.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeManager.HasIntervalPassed()) {
            Instantiate(explosionObject, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        } else if (!audioSource.isPlaying) {
            audioSource.PlayOneShot(fuseAC, 0.3f);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == Values.TAG_PLAYER) {
            audioSource.PlayOneShot(defuseAC[Random.Range(0, defuseAC.Length - 1)], 1f);
            Destroy(gameObject, 0.1f);
        }
    }
}
