using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI waterText;
    public TextMeshProUGUI stickText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waterText.text = Flowers.percentWatered.ToString()+" %";
        stickText.text = InventoryManager.stickCount.ToString();
    }
}
