using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    #region Singleton Initialize
    public static DialogueManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Warning! more than one DialogueManager!");
        } else
        {
            instance = this;
        }
    }

    #endregion

    bool dialogueActive = false;

    //public PlayerController player;
    public Canvas dialogueBox;
    CanvasGroup dialogueVisibility;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image portraitLeft;
    public Image portraitRight;
    public Sprite placeholderPortrait;
    //Add portrait variable

    private Queue<string> sentences;
    private Queue<DialogueNode> nodes;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        nodes = new Queue<DialogueNode>();
        dialogueVisibility = dialogueBox.GetComponent<CanvasGroup>();

        GameEvents.current.onDialogueStart += DialogueStart;
        GameEvents.current.onDialogueEnd += DialogueEnd;
    }

    private void Update()
    {
        //change to event?
        if (dialogueActive == true)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                DisplayNextSentence();
            }
        }
    }

    public void InputNewDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting converstation with " + dialogue.name);

        //player.ControlToggle();

        //nameText.text = dialogue.name;

        //sentences.Clear();
        //foreach(string sentence in dialogue.sentences)
        //{
        //    sentences.Enqueue(sentence);
        //}

        nodes.Clear();
        foreach(DialogueNode node in dialogue.dialogueTree)
        {
            nodes.Enqueue(node);
        }

        //dialogueVisibility.alpha = 1f;
        //dialogueVisibility.blocksRaycasts = true;

        //DisplayNextSentence();

        //player.ControlToggle();

    }

    public void DisplayNextSentence()
    {
        //if (sentences.Count == 0)
        //{
        //    EndDialogue();
        //    return;
        //}

        //string sentence = sentences.Dequeue();
        ////Debug.Log(sentence);
        //dialogueText.text = sentence;

        if (nodes.Count == 0)
        {
            GameEvents.current.DialogueEnd();
            //EndDialogue();
            return;
        }

        DialogueNode currentNode = nodes.Dequeue();

       if (currentNode.doAction == true)
        {
            currentNode.action.DoAction();
        }

        nameText.text = currentNode.name;
        dialogueText.text = currentNode.sentence;

        if (currentNode.portraitLeft == null)
        {
            portraitLeft.sprite = placeholderPortrait;
        } else
        {
            portraitLeft.sprite = currentNode.portraitLeft;
        }
        if (currentNode.portraitRight == null)
        {
            portraitRight.sprite = placeholderPortrait;
        }
        else
        {
            portraitRight.sprite = currentNode.portraitRight;
        }
    }

    //public void DisplayNextSentence(int choice)
    //{
    //    if (sentences.Count == 0)
    //    {
    //        EndDialogue();
    //        return;
    //    }

    //    // Add choice functionality

    //    string sentence = sentences.Dequeue();
    //    //Debug.Log(sentence);
    //    dialogueText.text = sentence;

    //}

    void EndDialogue()
    {
        //Debug.Log("End of conversation.");
        //player.ControlToggle();

        dialogueVisibility.alpha = 0f;
        dialogueVisibility.blocksRaycasts = false;

        //player.interacting = false;
    }

    void DialogueStart()
    {
        dialogueVisibility.alpha = 1f;
        dialogueVisibility.blocksRaycasts = true;
        dialogueActive = true;

        DisplayNextSentence();
    }

    void DialogueEnd()
    {
        dialogueVisibility.alpha = 0f;
        dialogueVisibility.blocksRaycasts = false;
        dialogueActive = false;
    }

    private void OnDestroy()
    {
        GameEvents.current.onDialogueStart -= DialogueStart;
        GameEvents.current.onDialogueEnd -= DialogueEnd;
    }
}
