using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveParent : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        //Adds to the list in the level manager - Matt
        LevelManager.interactables.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Do something on interaction.
    /// </summary>
    public virtual void DoSomething()
    {

    }

    public virtual void PlaceDown()
    {

    }
}
