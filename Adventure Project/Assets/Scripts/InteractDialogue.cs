﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDialogue : Interactable
{
    public Dialogue dialogue;

    public override void Interact()
    {
        //base.Interact();

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}