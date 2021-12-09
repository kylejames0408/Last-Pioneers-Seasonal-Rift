using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : InteractiveParent
{
    //Declared in inspector, will be updated soon - Matt
    public string type;
    [SerializeField] private GameObject self;

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
        //Debug.Log("Item");

        //Adds to inventoryManager and disables this - Matt
        InventoryManager.items.Add(this);
        self.SetActive(false);

    }

    public override void PlaceDown()
    {
        InventoryManager.items.Remove(this);
        self.SetActive(true);
    }
}
