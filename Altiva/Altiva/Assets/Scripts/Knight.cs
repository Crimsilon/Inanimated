using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour {

    //Public Variables
    public float rayMaxDistance;
    public float radius;
    public DialogueClass npcDialogue;


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

        if (lookingAtPlayer == true && Input.GetAxis("Fire1") > 0.0f)
        {
            if(inConversation == false)
            {
                ActivateDialogue();
            }
        }

        if (inConversation == true && Input.GetAxis("Fire1") > 0.0f)
        {
            ContinueDialogue();
        }

        if (Input.GetAxis("Fire1") > 0.0f)
        {
            if (clickOrSpaceInUse == false)
            {
                clickOrSpaceInUse = true;
            }
        }
        else
        {
            clickOrSpaceInUse = false;
        }
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
