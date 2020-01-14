using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : Interactable
{
    //[SerializeField]
    public GameObject interactGate;

    public Vector3 openPosition;
    public Vector3 closedPosition;

    public Animator animator;

    public void Start()
    {
        //closedPosition = interactObject.transform.position;
        //interactGate = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {

        if (!hasInteracted)
        {
            //Open gate
            //Play button animation

            interactGate.transform.position += openPosition;

            hasInteracted = true;
            //animator.DoorOpen = true;
            //Debug.Log("Gate is open!");
        } else
        {
            //Close gate
            //Play button animation

            interactGate.transform.position += closedPosition;

            hasInteracted = false;
            //Debug.Log("Gate is closed...");
        }
    }
}
