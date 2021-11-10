using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStar : MonoBehaviour
{

    public float speed;
    public long distance;
    public long time;

    TimeManager timeManager;
    Vector3 startPosition;
    Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        SetTimeManager();
        startPosition = new Vector3(transform.position.x, transform.position.y, 0);
        destination = new Vector3(transform.position.x, transform.position.y - distance, 0);
    }

    void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeManager.HasIntervalPassed()) {
            SetTimeManager();

            if (transform.position.y < startPosition.y) {
                destination = new Vector3(startPosition.x, startPosition.y + distance, 0);
            } else {
                destination = new Vector3(startPosition.x, startPosition.y - distance, 0);
            }
        }
    }

    private void SetTimeManager() {
        timeManager = new TimeManager(time, time);
        timeManager.Start();
    }
}
