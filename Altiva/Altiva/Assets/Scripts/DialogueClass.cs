﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueClass {

	public string npcName;

	[TextArea(2,3)]
	public string[] linesOfDialogue;
}
