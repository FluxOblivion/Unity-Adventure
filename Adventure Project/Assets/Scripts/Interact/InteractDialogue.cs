using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDialogue : Interactable
{
    public Dialogue dialogue;
    public Dialogue dialogueAfterInteract;
    //public DialogueNode[] dialogueTree;

    public void Start()
    {
        //GameEvents.current.onDialogueStart += DialogueStart;
        //GameEvents.current.onDialogueEnd += DialogueEnd;
    }

    public override void Interact()
    {
        //base.Interact();
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

        DialogueManager.instance.InputNewDialogue(dialogue);
        GameEvents.current.DialogueStart();
    }
}
