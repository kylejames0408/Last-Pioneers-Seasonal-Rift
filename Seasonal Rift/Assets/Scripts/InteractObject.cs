using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : InteractiveParent
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Do something on interaction.
    /// </summary>
    public override void DoSomething()
    {
        //this should be removed after sprint 1, this is just here to show you are actually interacting with the object
        switch (GameManager.gameState)
        {
            case GameState.Game:
                Debug.Log("Interactive");
                Dialogue dialogue = new Dialogue();
                dialogue.name = "";
                dialogue.sentances = new string[1];
                dialogue.sentances[0] = "You interacted with the object";
                GameManager.dialogueManager.StartDialogue(dialogue);
                break;
            case GameState.Dialogue:
                GameManager.dialogueManager.DisplayNextSentance();
                break;
        }
    }
}
