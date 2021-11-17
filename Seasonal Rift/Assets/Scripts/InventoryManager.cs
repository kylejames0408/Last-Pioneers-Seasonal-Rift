using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static List<ItemObject> items = new List<ItemObject>();

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }
}
