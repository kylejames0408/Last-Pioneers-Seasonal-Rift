using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : InteractObject
{

    public bool watered;
    public static int percentWatered;
    // Start is called before the first frame update
    void Start()
    {
        watered = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    /// <summary>
    /// Waters the bucket
    /// </summary>
    public override void DoSomething()
    {
        for (int i = 0; i < InventoryManager.items.Count; i++)
        {
            if (InventoryManager.items[i].type == "bucket")
            {
                Bucket bucket = (Bucket)InventoryManager.items[i];
                if(bucket.full && !watered)
                {
                    bucket.full = false;
                    watered = true;
                    percentWatered += 50;
                    Debug.Log("bucket was emptied");
                    bucket.PlaceDown();
                }
                else if(!bucket.full)
                {
                    Debug.Log("Bucket is empty");
                    bucket.PlaceDown();
                }
                else if(watered)
                {
                    Debug.Log("This was already watered");
                }

            }
        }
    }
}
