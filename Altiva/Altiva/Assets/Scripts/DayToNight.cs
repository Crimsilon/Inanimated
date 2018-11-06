using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayToNight : MonoBehaviour {

	//Public Variables
	public float rotationValue;
	public float maxTime;
	public float sunOut;
	public float moonHidden;
	public float timeToIlluminate;

	//Private Variables
	private float timeCount;

	// Use this for initialization
	void Start () {
		timeCount = 0.0f;

		//Child 1 Moon, Child 0 Sun
//		gameObject.transform.GetChild (1).gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (timeCount < maxTime) {
			timeCount = timeCount + (Time.deltaTime / rotationValue);
			transform.Rotate (Vector3.right * Time.deltaTime);
		}

		if (timeCount > sunOut) {
			gameObject.transform.GetChild (0).gameObject.SetActive (false);
		}
		if (timeCount > sunOut - timeToIlluminate && gameObject.transform.GetChild (0).gameObject.activeInHierarchy == true){
			gameObject.transform.GetChild (0).gameObject.GetComponent<Light> ().intensity -= Time.deltaTime / timeToIlluminate;
		}
//		if (timeCount > moonHidden){
//			gameObject.transform.GetChild (1).gameObject.SetActive (true);
//		}
//		if (timeCount > moonHidden + (timeToIlluminate * 2.0f) && gameObject.transform.GetChild (1).gameObject.activeInHierarchy == true) {
//			if (gameObject.transform.GetChild (1).gameObject.GetComponent<Light> ().intensity < 0.75f) {
//				gameObject.transform.GetChild (1).gameObject.GetComponent<Light> ().intensity += Time.deltaTime / timeToIlluminate;
//			}
//		}
	}
}
