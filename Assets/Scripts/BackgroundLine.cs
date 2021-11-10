using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLine : MonoBehaviour
{
	public float speed;
	public long idleTime;
	public GameObject startPosition;
	public GameObject endPosition;

	TimeManager timeManager;
	
    // Start is called before the first frame update
    void Start()
    {
        SetTimeManager();
    }

	void FixedUpdate() {
		transform.position = Vector3.MoveTowards(transform.position, endPosition.transform.position, Time.deltaTime * speed);
	}

    // Update is called once per frame
    void Update()
    {
        if (timeManager.HasIntervalPassed()) {
			transform.position = startPosition.transform.position;
			
			SetTimeManager();
		}
    }
	
	private void SetTimeManager() {
		timeManager = new TimeManager(idleTime, idleTime);
		timeManager.Start();
	}
}
