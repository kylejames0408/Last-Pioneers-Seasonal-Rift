using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A class to load in dialogue objects
/// </summary>
public class DialogueManager : MonoBehaviour
{
    // Fields
    private Queue<string> sentances;

    public Text nameText;
    public Text dialogueText;

    public GameObject dialogueBox;


    /// <summary>
    /// Initializes DialogueManager fields.
    /// </summary>
    void Start()
    {
        // Initialize Fields
        sentances = new Queue<string>();


        dialogueBox = GameObject.FindWithTag("dialogueBox");
        dialogueBox.GetComponent<Image>().enabled = false;
    }



    /// <summary>
    /// Runs through provided dialogue data.
    /// </summary>
    /// <param name="dialogue">The dialogue to run 
    public void StartDialogue(Dialogue dialogue)
    {

        GameManager.gameState = GameState.Dialogue;
        dialogueBox.GetComponent<Image>().enabled = true;
        // Set the NPC name text
        nameText.text = dialogue.name;

        // Clears sentences and sentences spoken
        sentances.Clear();


        // For each sentence in the provided dialogue
        foreach (string sentance in dialogue.sentances)
        {
            // Enqueue the sentence
            sentances.Enqueue(sentance);
        }

        // Display the next sentence in the dialogue
        DisplayNextSentance();
    }


    public void ContinueDialogue(Dialogue dialogue)
    {
        foreach (string sentance in dialogue.sentances)
        {
            // Enqueue the sentence
            sentances.Enqueue(sentance);
        }
    }


    /// <summary>
    /// Displays the next sentence in the sentence queue, or end the dialogue.
    /// </summary>
    public void DisplayNextSentance()
    {
        // Temporary Fields
        Queue<string> dialogueChosen;

        // Set the dialogue to new sentences
        dialogueChosen = sentances;

        // If there's no dialogue
        if (dialogueChosen.Count == 0)
        {
            // Return the game state to the game
            GameManager.gameState = GameState.Game;

            // Empty the text
            nameText.text = "";
            dialogueText.text = "";
            dialogueBox.GetComponent<Image>().enabled = false;
        }
        else
        {
            // Dequeue the dialogue
            string sentance = dialogueChosen.Dequeue();
            

            // Set the sentence to display
            dialogueText.text = sentance;
        }



    }
}
