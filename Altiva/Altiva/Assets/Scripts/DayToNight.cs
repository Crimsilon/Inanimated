using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayToNight : MonoBehaviour {

	//Public Variables
	public float rotationValue;
	public float maxTime;

	//Private Variables
	private float timeCount;

	// Use this for initialization
	void Start () {
		timeCount = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		if (timeCount < maxTime) {
			timeCount = timeCount + (Time.deltaTime / rotationValue);
			transform.Rotate (Vector3.right * Time.deltaTime);
		}
	}
}
