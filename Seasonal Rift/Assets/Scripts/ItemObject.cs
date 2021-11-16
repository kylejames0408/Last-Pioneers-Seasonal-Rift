using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        //Adds to the list in the level manager - Matt
        LevelManager.items.Add(this);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
