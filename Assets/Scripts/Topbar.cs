using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topbar : MonoBehaviour
{

    public float speed;
    public float rotation;
    public long rotationTime;
    public long distance;
    public long time;

    bool isMovingRight;
    bool isRotatingRight;
    TimeManager timeManager;
    TimeManager rotationTimeManager;
    Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        isMovingRight = false;
        isRotatingRight = false;
        destination = new Vector3(transform.position.x - distance, transform.position.y, 0);
        SetTimeManager();
        SetRotationTimeManager();
    }

    void FixedUpdate() {
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
        if (isRotatingRight) {
            transform.Rotate(0, 0, rotation * Time.deltaTime);
        } else {
            transform.Rotate(0, 0, rotation * Time.deltaTime * (-1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeManager.HasIntervalPassed()) {
            if (isMovingRight) {
                destination = new Vector3(transform.position.x - distance, transform.position.y, 0);
            } else {
                destination = new Vector3(transform.position.x + distance, transform.position.y, 0);
            }

            isMovingRight = !isMovingRight;
            SetTimeManager();
        }

        if (rotationTimeManager.HasIntervalPassed()) {
            isRotatingRight = !isRotatingRight;

            SetRotationTimeManager();
        }
    }

    private void SetTimeManager() {
        timeManager = new TimeManager(time, time);
        timeManager.Start();
    }

    private void SetRotationTimeManager() {
        rotationTimeManager = new TimeManager(rotationTime, rotationTime);
        rotationTimeManager.Start();
    }
}
