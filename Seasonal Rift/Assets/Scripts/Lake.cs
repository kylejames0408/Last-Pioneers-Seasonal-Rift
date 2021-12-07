using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lake : InteractObject
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
    /// Fills the bucket
    /// </summary>
    public override void DoSomething()
    {
        for (int i = 0; i < InventoryManager.items.Count; i++)
        {
            if (InventoryManager.items[i].type == "bucket")
            {
                Bucket bucket = (Bucket)InventoryManager.items[i];
                bucket.full = true;
                Debug.Log("Filled the bucket");
            }
        }
    }
}
