using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static List<ItemObject> items = new List<ItemObject>();
    public static int stickCount;
    public static bool denCreated;

    // Start is called before the first frame update
    void Start()
    {
        stickCount = 0;
        denCreated = false;
    }

    // Update is called once per frame
    void Update()
    {

        //i is basically used to view the inventory
        if (Input.GetKeyDown("i"))
        {
            for(int i = 0; i < items.Count; i ++)
            {
                Debug.Log(items[i].type);
            }
            if(denCreated)
            {
                Debug.Log("den");
            }
        }

        if(!denCreated)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].type == "stick")
                {
                    stickCount++;
                }
            }

            if (stickCount == 5)
            {
                denCreated = true;
                Debug.Log("Den Created");

                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].type == "stick")
                    {
                        items.RemoveAt(i);
                        i--;
                    }
                }
            }
            stickCount = 0;
        }


    }
}
