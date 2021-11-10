using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{

    public float speed;
    public Animator animator;
    public AudioClip[] movementAC;
    public AudioClip idleAC;

    AudioSource audioSource;
    bool facingLeft;
    GameObject player;
    State state;
    TimeManager timeManager;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        facingLeft = true;
        player = GameObject.FindGameObjectsWithTag(Values.TAG_PLAYER)[0];
        state = State.IDLE;
        timeManager = new TimeManager(Values.ENEMY_SOLDIER_IDLE_TIME, Values.ENEMY_SOLDIER_IDLE_TIME);
        timeManager.Start();
    }

    void FixedUpdate() {
        if (state == State.ACTIVE) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);

            Flip(player.transform.position.x - transform.position.x < 0);
        }
    }

    void Update() {
        if (timeManager.HasIntervalPassed() && state == State.IDLE) {
            state = State.ACTIVE;
            animator.SetBool("isActive", true);
        }

        if (state == State.IDLE && !audioSource.isPlaying) {
            audioSource.PlayOneShot(idleAC, 0.2f);
        } else if (state == State.ACTIVE && !audioSource.isPlaying) {
            audioSource.PlayOneShot(movementAC[Random.Range(0, movementAC.Length - 1)], 0.2f);
        }
    }

    public State GetState() {
        return this.state;
    }

    void Flip(bool changeToFaceLeft) {
        if (facingLeft != changeToFaceLeft) {
            facingLeft = changeToFaceLeft;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    public enum State {
        IDLE,
        ACTIVE
    }
}