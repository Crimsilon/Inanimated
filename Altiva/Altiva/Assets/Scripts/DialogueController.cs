using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

	//public variables
	public Text npcNameText;
	public Text npcDialogueText;
	public GameObject textBox;

	//private variables
	private Queue<string> linesOfDialogue;
    private bool talking;


	// Use this for initialization
	void Start () {
		linesOfDialogue = new Queue<string> ();
        talking = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void StartDialogue(DialogueClass npcDialogue){

		textBox.SetActive (true);

		npcNameText.text = npcDialogue.npcName;

		linesOfDialogue.Clear ();

		foreach (string line in npcDialogue.linesOfDialogue) {
			linesOfDialogue.Enqueue (line);
		}

		ShowNextLine ();
	}
	public void ShowNextLine(){
		if (linesOfDialogue.Count == 0) {
			EndDialogue ();
			return;
		}

		string line = linesOfDialogue.Dequeue ();
//		npcDialogueText.text = line;
		StopAllCoroutines();
		StartCoroutine (LineByCharacter(line));
	}
	IEnumerator LineByCharacter(string line){
		npcDialogueText.text = "";
		foreach (char character in line.ToCharArray()) {
			npcDialogueText.text += character;
			yield return null;
		}
	}

	public void EndDialogue(){
		textBox.SetActive (false);
	}
}
