using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	//Public Variables
	[HideInInspector]public bool inConversation;
	[HideInInspector]public bool lookingAtSpeaker;
	public float coins;
	public float speed;
	public float rayMaxDistance;
	public CharacterDialogue characterDialogueScript;

	//Private Variables
	private int layerMask;
	private bool inConveration;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;

		//Layer 9 is "CanSpeak" Layer
		layerMask = 1 << 9;
		lookingAtSpeaker = false;
		inConversation = false;
	}

	// Update is called once per frame
	void Update () {
		//DEBUG NO CURSOR LOCK
		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}

		//Is player looking at a game object that CanSpeak?

		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out hit, rayMaxDistance, layerMask)) {
//			Debug.Log ("Hit something.");
			inConversation = hit.collider.gameObject.GetComponent<CharacterDialogue>().inConversation;
			lookingAtSpeaker = true;
		} else {
			lookingAtSpeaker = false;
		}
	}

	void FixedUpdate (){
		//MOVEMENT
		if (inConversation == false) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			transform.Translate (moveHorizontal / speed, 0.0f, moveVertical / speed);
		}
	}

	void OnTriggerStay (Collider other){
		if (other.tag == "ToScene1" && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))){
			Debug.Log ("Loading Scene?");
			SceneManager.LoadScene (1);
			Debug.Log ("Scene Loaded?");
		}
		if (other.tag == "ToScene2" && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))){
			SceneManager.LoadScene (2);
		}
	}
}