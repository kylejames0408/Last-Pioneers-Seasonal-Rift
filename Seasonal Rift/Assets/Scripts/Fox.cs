using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : InteractiveParent
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
        Debug.Log("Fox");
    }
}
