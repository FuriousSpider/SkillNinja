using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesHandler : MonoBehaviour
{

    State state;
    TimeManager timeManager;
    AudioSource audioSource;

    public AudioClip activeAC;
    public AudioClip idleAC;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        state = State.IDLE;
        timeManager = new TimeManager(Values.ENEMY_SPIKES_IDLE_TIME, Values.ENEMY_SPIKES_IDLE_TIME);

        timeManager.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.IDLE && timeManager.HasIntervalPassed()) {
            audioSource.Stop();
            audioSource.PlayOneShot(activeAC, 0.5f);
            state = State.ACTIVE;

            timeManager = new TimeManager(Values.ENEMY_SPIKES_ACTIVE_TIME, Values.ENEMY_SPIKES_ACTIVE_TIME);
            timeManager.Start();    

            animator.SetBool("isActive", true);
        } else if (state == State.ACTIVE && timeManager.HasIntervalPassed()) {
            Destroy(gameObject);
        }

        if (!audioSource.isPlaying && state == State.IDLE) {
            audioSource.PlayOneShot(idleAC, 0.2f);
        }
    }

    public State GetState() {
        return state;
    }

    public enum State {
        IDLE,
        ACTIVE
    }
}
