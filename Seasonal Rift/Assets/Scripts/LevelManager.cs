using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    //public static List<ItemObject> items = new List<ItemObject>();
    //public static List<InteractObject> interactables = new List<InteractObject>();
    public static List<InteractiveParent> interactables = new List<InteractiveParent>();


    //These variables are initiated through Unity inspector - Matt
    public Camera mainCam;
    public Player playerScript;
    public GameObject player;
    public LayerMask interactableLayers; //This tells which layer the interactive objects are on - Matt

    private float maxDistance; //Distance for interaction, larger number means you can interact from farther away - Matt
    private InteractiveParent currentInteraction; //Will store the object which can be interacted with - Matt
    private RaycastHit hit; //Basically used to hold the object in the center of the camera - Matt

    // Start is called before the first frame update
    void Start()
    {
        //Set arbitrarily - Matt
        maxDistance = 5;
    }

    // Update is called once per frame
    void Update()
    {

        //Basically this checks if something is within maxDistance from the center of the camera in the direction the camera is pointing. Only works on the specific layer - Matt
        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, maxDistance, interactableLayers))
        {
            //Debug.Log("Hit");
            currentInteraction = hit.collider.GetComponent<InteractiveParent>();

            if (Input.GetKeyDown("e"))
            {
                currentInteraction.DoSomething();
            }
        }
        else
        {
            currentInteraction = null; //Clears interaction - Matt
        }

    }

}
