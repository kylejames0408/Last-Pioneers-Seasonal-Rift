using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : InteractiveParent
{
    //base fox dialogue
    public Dialogue dialogue;
    public Dialogue dialogueSecond;
    public Dialogue dialogueThird;
    public Dialogue dialogueStick;
    public Dialogue dialogueDen;
    public Dialogue dialogueWatered;
    public Dialogue dialogueNoWater;
    public Dialogue dialogueNoSticks;
    public Dialogue dialogueLast;

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
        dialogue.sentances = new string[2];
        dialogue.sentances[0] = "Hmm... whats this? A human has entered the snow globe?";
        dialogue.sentances[1] = "Listen well human, I do not currry any favor for those of your kind. Leave me alone if you know whats good for you.";

        dialogueSecond = new Dialogue();
        dialogueSecond.name = "Fox";
        dialogueSecond.sentances = new string[3];
        dialogueSecond.sentances[0] = "You're an insistent one, aren't you... well I suppose there is no harm in sharing with you while you are trapped in here, as long as it keeps you from bothering me.";
        dialogueSecond.sentances[1] = "I need some help taking care of some things within the globe, and you will be the one to help me. It will be a good distraction for you at the least.";
        dialogueSecond.sentances[2] = "First, I need you to fill that bucket with water and tend to all the flowers. Afer that you should collect 5 sticks to help me build my den. Come back to me when you're done";

        dialogueThird = new Dialogue();
        dialogueThird.name = "Fox";
        dialogueThird.sentances = new string[1];
        dialogueThird.sentances[0] = "Didn't you hear me last time? You need to water the flowers and collect the sticks for my den.";

        dialogueStick = new Dialogue();
        dialogueStick.name = "Fox";
        dialogueStick.sentances = new string[1];
        dialogueStick.sentances[0] = "Good, you brought all the sticks. Why don't you work on building the actual den now.";


        dialogueDen = new Dialogue();
        dialogueDen.name = "Fox";
        dialogueDen.sentances = new string[1];
        dialogueDen.sentances[0] = "Hmm. Well I guess you could call this a den. I would have thought a development obsessed human such as yourself might be able to do a better job, but this will do.";



        dialogueWatered = new Dialogue();
        dialogueWatered.name = "Fox";
        dialogueWatered.sentances = new string[1];
        dialogueWatered.sentances[0] = "It looks like those flowers are fully watered now. You can really tell how thirsty they were for that water.";

        dialogueNoWater = new Dialogue();
        dialogueNoWater.name = "Fox";
        dialogueNoWater.sentances = new string[1];
        dialogueNoWater.sentances[0] = "You still need to water those flowers. Pick up and fill that bucket first, and then pour the water on the flowers.";

        dialogueNoSticks = new Dialogue();
        dialogueNoSticks.name = "Fox";
        dialogueNoSticks.sentances = new string[1];
        dialogueNoSticks.sentances[0] = "You still don't have enough sticks for my den. Keep looking around the tree to find a bit more.";


        dialogueLast = new Dialogue();
        dialogueLast.name = "Fox";
        dialogueLast.sentances = new string[2];
        dialogueLast.sentances[0] = "Hmm. Even though you're human, you seem to have something different about you. Perhaps my initial judgement of you was misaligned with your true nature.";
        dialogueLast.sentances[1] = "Come with me human. Your people have done untold amounts of damage to this world, but there is a chance you could make up for their mistakes.";

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
        if (InventoryManager.stickCount == 5 && !InventoryManager.denCreated)
        {
            interactionNum = 3;
        }
        else if (InventoryManager.denCreated)
        {
            interactionNum = 3;
        }
        if(Flowers.percentWatered == 100)
        {
            interactionNum = 3;
        }



        switch (GameManager.gameState)
        {
            case GameState.Game:
                //start the dialogue based on what the current interaction num is
                switch(interactionNum)
                {
                    //case 0-2 intro dialogue
                    case 0:
                        GameManager.dialogueManager.StartDialogue(dialogue);
                        interactionNum++;
                        break;

                    case 1:
                        GameManager.dialogueManager.StartDialogue(dialogueSecond);
                        interactionNum++;
                        break;
                    case 2:
                        GameManager.dialogueManager.StartDialogue(dialogueThird);
                        break;
                    case 3:
                        //case 3: dialogue that begins when quest first triggered. dymanically responds based on current progress
                        if (InventoryManager.stickCount == 5 && Den.broken == true)
                        {
                            GameManager.dialogueManager.StartDialogue(dialogueStick);
                        }
                        else if (Den.broken == false)
                        {
                            GameManager.dialogueManager.StartDialogue(dialogueDen);
                        }
                        else
                        {
                            GameManager.dialogueManager.StartDialogue(dialogueNoSticks);
                        }

                        if (Flowers.percentWatered == 100)
                        {
                            GameManager.dialogueManager.ContinueDialogue(dialogueWatered);
                        }
                        else
                        {
                            GameManager.dialogueManager.ContinueDialogue(dialogueNoWater);
                        }


                        if(Den.broken == false && Flowers.percentWatered == 100)
                        {
                            GameManager.dialogueManager.ContinueDialogue(dialogueLast);
                            interactionNum++;
                        }
                        break;

                    case 4:
                        GameManager.dialogueManager.StartDialogue(dialogueLast);
                        break;
                }
                break;
            case GameState.Dialogue:
                GameManager.dialogueManager.DisplayNextSentance();
                break;
        }

    }
}
