using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//Public Variables
	public float speed;
	public float rayMaxDistance;

	//Private Variables
	private int layerMask;
	private bool lookingAtSpeaker;
	private bool inConveration;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;

		//Layer 9 is "CanSpeak" Layer
		layerMask = 1 << 9;
		lookingAtSpeaker = false;
	}

	// Update is called once per frame
	void Update () {
		//DEBUG NO CURSOR LOCK
		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}

		//Is player looking at a game object that CanSpeak?
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), rayMaxDistance, layerMask)) {
//			Debug.Log ("Hit something.");
			lookingAtSpeaker = true;
		} else {
			lookingAtSpeaker = false;
		}
	}

	void FixedUpdate (){
		//MOVEMENT
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		transform.Translate(moveHorizontal / speed, 0.0f, moveVertical / speed);
	}

	void OnTriggerStay (Collider other){
		if (other.tag == "KnightDay1" && lookingAtSpeaker == true) {
			if (Input.GetAxis ("Fire1") > 0.0f) {
//				other.GetComponent<DialogueTrigger> ().ActivateDialogue;
			}
		}
	}
}
