using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public DialogueClass npcDialogue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ActivateDialogue(){
		FindObjectOfType<DialogueController> ().StartDialogue (npcDialogue);
	}
}
