using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class to store dialogue information. Should be created, filled with sentances, and then passed into 
/// DialogueManager using StartDialogue()
/// </summary>
public class Dialogue
{
    // Fields
    public string name;

    [TextArea(3, 10)]
    public string[] sentances;


}
