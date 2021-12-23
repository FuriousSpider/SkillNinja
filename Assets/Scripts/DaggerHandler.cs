using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerHandler : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public AudioClip audioClip;

    AudioSource audioSource;
    GameObject target;
    State state;
    float volume;

    void Start() {
        volume = PlayerPrefsHandler.GetSoundsVolume();
        audioSource = gameObject.AddComponent<AudioSource>();
        state = State.IDLE;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == Values.TAG_PLAYER) {
            state = State.ACTIVE;
            animator.SetBool("isActive", true);
        }
    }

    void FixedUpdate() {
        if (state == State.ACTIVE) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        }

        if (state == State.ACTIVE && !audioSource.isPlaying) {
            audioSource.PlayOneShot(audioClip, volume * 0.5f);
        }
    }

    public void SetTarget(GameObject target) {
        this.target = target;
    }

    public State GetState() {
        return this.state;
    }

    public GameObject GetTarget() {
        return this.target;
    }

    public enum State {
        IDLE,
        ACTIVE
    }
}
