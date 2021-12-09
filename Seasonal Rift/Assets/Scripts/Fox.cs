using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : InteractiveParent
{
    //base fox dialogue
    public Dialogue dialogue;
    public Dialogue dialogueSecond;

    //interaction number keeps track of which dialogue should be used
    public int interactionNum;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //set up dialogue
        interactionNum = 0;
        dialogue = new Dialogue();
        dialogue.name = "Fox";
        dialogue.sentances = new string[1];
        dialogue.sentances[0] = "im the fox";

        dialogueSecond = new Dialogue();
        dialogueSecond.name = "Fox";
        dialogueSecond.sentances = new string[2];
        dialogueSecond.sentances[0] = "im the fox sajjdsajd";
        dialogueSecond.sentances[1] = "gameing";

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }

    /// <summary>
    /// Do something on interaction.
    /// </summary>
    public override void DoSomething()
    {

        switch (GameManager.gameState)
        {
            case GameState.Game:
                //start the dialogue based on what the current interaction num is
                switch(interactionNum)
                {
                    case 0:
                        GameManager.dialogueManager.StartDialogue(dialogue);
                        interactionNum++;
                        break;

                    case 1:
                        GameManager.dialogueManager.StartDialogue(dialogueSecond);
                        break;
                }
                break;
            case GameState.Dialogue:
                GameManager.dialogueManager.DisplayNextSentance();
                break;
        }

    }
}
