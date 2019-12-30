using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    //public string name;

    //[TextArea(3,10)]
    //public string[] sentences;

    public DialogueNode[] dialogueTree;


}
