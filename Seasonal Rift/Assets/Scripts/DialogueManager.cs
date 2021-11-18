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


    /// <summary>
    /// Initializes DialogueManager fields.
    /// </summary>
    void Start()
    {
        // Initialize Fields
        sentances = new Queue<string>();

    }



    /// <summary>
    /// Runs through provided dialogue data.
    /// </summary>
    /// <param name="dialogue">The dialogue to run 
    public void StartDialogue(Dialogue dialogue)
    {

        GameManager.gameState = GameState.Dialogue;
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
