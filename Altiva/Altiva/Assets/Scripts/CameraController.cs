using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//public variables
	public float mouseSensitivity;
	public float mouseSmooth;
    public float canMove;

	//	public float maxYAngle;

	//private variables
	private GameObject player;
	private Vector2 cameraRotation;
	private Vector2 smoothRotation;

	// Use this for initialization
	void Start () {
		player = this.transform.parent.gameObject;
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		Vector2 mouseMovement = new Vector2 (Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		mouseMovement = Vector2.Scale (mouseMovement, new Vector2 (mouseSensitivity, mouseSensitivity));
		smoothRotation.x = Mathf.Lerp (smoothRotation.x, mouseMovement.x, 1.0f / mouseSmooth);
		smoothRotation.y = Mathf.Lerp (smoothRotation.y, mouseMovement.y, 1.0f / mouseSmooth);
		cameraRotation = cameraRotation + smoothRotation;

		cameraRotation.y = Mathf.Clamp (cameraRotation.y, -90.0f, 90.0f);

		transform.localRotation = Quaternion.AngleAxis (-cameraRotation.y, Vector3.right);
		player.transform.localRotation = Quaternion.AngleAxis (cameraRotation.x, player.transform.up);
	}
}
