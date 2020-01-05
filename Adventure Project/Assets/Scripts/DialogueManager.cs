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

    public PlayerController player;
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
    }

    private void Update()
    {
        if (player.interacting == true)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                DisplayNextSentence();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting converstation with " + dialogue.name);

        player.ControlToggle();

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

        dialogueVisibility.alpha = 1f;
        dialogueVisibility.blocksRaycasts = true;

        DisplayNextSentence();

        player.interacting = true;

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
            EndDialogue();
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
        // Set portrait
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
        player.ControlToggle();

        dialogueVisibility.alpha = 0f;
        dialogueVisibility.blocksRaycasts = false;

        player.interacting = false;
    }

}
