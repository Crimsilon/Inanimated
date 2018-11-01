﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour {

    //Public Variables
    public float rayMaxDistance;
    public float radius;
    public DialogueClass npcDialogue;
    public PlayerController playerScript;

    //Private Variables
    private int layerMask;
    private bool lookingAtPlayer;
    private bool inConversation;
    private bool clickOrSpaceInUse;
    private bool playerLooking;


    // Use this for initialization
    void Start () {
        layerMask = 1 << 10;
        inConversation = false;
	}
	
	// Update is called once per frame
	void Update () {

        //https://answers.unity.com/questions/537673/raycast-object-tag-check.html

        RaycastHit hit;
        if (Physics.SphereCast(transform.position, radius, transform.TransformDirection(Vector3.forward), out hit, rayMaxDistance, layerMask))
        {
            Debug.Log("Hit Player.");
            lookingAtPlayer = true;
        }
        else
        {
            lookingAtPlayer = false;
        }

        if (lookingAtPlayer == true && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)))
        {
            if(inConversation == false)
            {
                ActivateDialogue();
            }
        }

        if (inConversation == true && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)))
        {
            ContinueDialogue();

        }

//        if (GetComponent<DialogueController>().EndDialogue())
//        {
//
//        }
    }

    public void ActivateDialogue()
    {
        FindObjectOfType<DialogueController>().StartDialogue(npcDialogue);
        inConversation = true;
    }

    public void ContinueDialogue()
    {
        FindObjectOfType<DialogueController>().ShowNextLine();
    }
}
