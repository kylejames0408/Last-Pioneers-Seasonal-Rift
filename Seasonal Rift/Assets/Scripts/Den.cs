using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Den : InteractObject
{
    public static bool broken;
    public GameObject brokenDen;
    public GameObject fixedDen;

    // Start is called before the first frame update
    void Start()
    {
        broken = true;
        fixedDen.SetActive(false);
        brokenDen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Fills the bucket
    /// </summary>
    public override void DoSomething()
    {
        if(InventoryManager.stickCount == 5)
        {
            broken = false;
            fixedDen.SetActive(true);
            brokenDen.SetActive(false);

            switch (GameManager.gameState)
            {
                case GameState.Game:
                    Dialogue dialogue = new Dialogue();
                    dialogue.name = "";
                    dialogue.sentances = new string[1];
                    dialogue.sentances[0] = "The den has been fixed!";
                    GameManager.dialogueManager.StartDialogue(dialogue);
                    break;
                case GameState.Dialogue:
                    GameManager.dialogueManager.DisplayNextSentance();
                    break;
            }
        }
        else
        {
            switch (GameManager.gameState)
            {
                case GameState.Game:
                    Dialogue dialogue = new Dialogue();
                    dialogue.name = "";
                    dialogue.sentances = new string[1];
                    dialogue.sentances[0] = "Collect 5 sitcks to fix the den";
                    GameManager.dialogueManager.StartDialogue(dialogue);
                    break;
                case GameState.Dialogue:
                    GameManager.dialogueManager.DisplayNextSentance();
                    break;
            }
        }
    }
}