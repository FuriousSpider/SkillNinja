using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBaseHandler : MonoBehaviour
{
    public GameObject laserBeam;
    public AudioClip activeAC;
    public AudioClip idleAC;

    AudioSource audioSource;
    State state;
    TimeManager timeManager;
    List<GameObject> lasersList;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        state = State.IDLE;
        timeManager = new TimeManager(Values.ENEMY_LASER_IDLE_TIME, Values.ENEMY_LASER_IDLE_TIME);
        lasersList = new List<GameObject>();

        timeManager.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.IDLE && timeManager.HasIntervalPassed()) {
            audioSource.Stop();
            state = State.ACTIVE;

            for (int i = 0; i < Values.ENEMY_LASER_NUMBER_OF_BEAMS; i++) {
                lasersList.Add(GetLaserBeam(i));
            }

            timeManager = new TimeManager(Values.ENEMY_LASER_ACTIVE_TIME, Values.ENEMY_LASER_ACTIVE_TIME);
            timeManager.Start();
        } else if (state == State.ACTIVE && timeManager.HasIntervalPassed()) {
            for (int i = 0; i < Values.ENEMY_LASER_NUMBER_OF_BEAMS; i++) {
                Destroy(lasersList[i]);
            }
            Destroy(gameObject);
        }

        if (!audioSource.isPlaying && state == State.ACTIVE) {
            audioSource.PlayOneShot(activeAC, 0.5f);
        } else if (!audioSource.isPlaying && state == State.IDLE) {
            audioSource.PlayOneShot(idleAC, 0.2f);
        }
    }

    private GameObject GetLaserBeam(int index) {
        GameObject obj = Instantiate(laserBeam);
        Vector3 position = gameObject.transform.position;
        
        SpriteRenderer thisRenderer = gameObject.GetComponent<SpriteRenderer>();
        BoxCollider2D objCollider = obj.GetComponent<BoxCollider2D>();

        switch (index) {
            case 0:
                position.x -= objCollider.bounds.size.x / 2 + thisRenderer.bounds.size.x / 2 - Values.ENEMY_LASER_BASE_LEFT_OFFSET;
                position.y += Values.ENEMY_LASER_BASE_LEFT_RIGHT_VERTICAL_OFFSET;
                obj.transform.position = position;
                break;
            case 1:
                position.y += objCollider.bounds.size.x / 2 + thisRenderer.bounds.size.x / 2  - Values.ENEMY_LASER_BASE_TOP_OFFSET;
                obj.transform.position = position;
                obj.transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
            case 2:
                position.x += objCollider.bounds.size.x / 2 + thisRenderer.bounds.size.x / 2  - Values.ENEMY_LASER_BASE_RIGHT_OFFSET;
                position.y += Values.ENEMY_LASER_BASE_LEFT_RIGHT_VERTICAL_OFFSET;
                obj.transform.position = position;
                obj.transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            default:
                position.y -= objCollider.bounds.size.x / 2 + thisRenderer.bounds.size.x / 2  - Values.ENEMY_LASER_BASE_BOTTOM_OFFSET;
                obj.transform.position = position;
                obj.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
        }
        return obj;
    }

    public enum State {
        IDLE,
        ACTIVE
    }
}