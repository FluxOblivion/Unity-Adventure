using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public PlayerController player;
    public Canvas dialogueBox;
    CanvasGroup dialogueVisibility;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
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

        nameText.text = dialogue.name;

        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        dialogueVisibility.alpha = 1f;
        dialogueVisibility.blocksRaycasts = true;

        DisplayNextSentence();

        player.interacting = true;

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    public void DisplayNextSentence(int choice)
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        // Add choice functionality

        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        //Debug.Log("End of conversation.");
        player.ControlToggle();

        dialogueVisibility.alpha = 0f;
        dialogueVisibility.blocksRaycasts = false;

        player.interacting = false;
    }

}
