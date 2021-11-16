using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static List<ItemObject> items = new List<ItemObject>();
    public static List<InteractObject> interactables = new List<InteractObject>();

    //These variables are initiated through Unity inspector - Matt
    public Player playerScript;
    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    //This method is currently just the detection from the Halloween Game, it will change soon
    //Once I see how the first person movement is going and brainstorm a little on how to optimize it then I'll change it
    //Love, Matt :P

    /// <summary>
    /// This will test whether an object is in the interaction range of the player
    /// </summary>
    /// <param name="gameObject"></param>
    bool InPlayerRange(GameObject gameObject)
    {
        // get extents of player +/- some number that I change all the time
        float playerMinX = player.transform.position.x - player.GetComponent<BoxCollider2D>().size.x + player.GetComponent<BoxCollider2D>().offset.x;
        playerMinX -= .1f;
        float playerMaxX = player.transform.position.x + player.GetComponent<BoxCollider2D>().size.x + player.GetComponent<BoxCollider2D>().offset.x;
        playerMaxX += .1f;
        float playerMinY = player.transform.position.y - player.GetComponent<BoxCollider2D>().size.y + player.GetComponent<BoxCollider2D>().offset.y;
        playerMinY -= .1f;
        float playerMaxY = player.transform.position.y + player.GetComponent<BoxCollider2D>().size.y + player.GetComponent<BoxCollider2D>().offset.y;
        playerMaxY += .1f;

        // get horizontal extents of lantern
        //Should technically account for offsets but whatever
        float objectMinX = gameObject.transform.position.x - gameObject.GetComponent<BoxCollider2D>().size.x;
        float objectMaxX = gameObject.transform.position.x + gameObject.GetComponent<BoxCollider2D>().size.x;
        float objectMinY = gameObject.transform.position.y - gameObject.GetComponent<BoxCollider2D>().size.y;
        float objectMaxY = gameObject.transform.position.y + gameObject.GetComponent<BoxCollider2D>().size.y;

        // checks if one sprite is completely seperated from the other
        if (playerMaxX < objectMinX) //player is completely to the left of lantern
        {
            //Debug.Log("player too far to the left");
            return false;
        }

        if (objectMaxX < playerMinX) //lantern is completely to the left of player
        {
            //Debug.Log("player too far to the right");
            return false;
        }
        if (playerMaxY < objectMinY) //player is completely below lantern
        {
            //Debug.Log("player too far down");
            return false;
        }
        if (objectMaxY < playerMinY) //lantern is completely below player
        {
            //Debug.Log("player too far up");
            return false;
        }

        //At this point the player is in range to grab, we want to check if he's facing the right direction tho
        //These two variables are reset to be JUST the player
        playerMinX = player.transform.position.x - player.GetComponent<BoxCollider2D>().size.x + player.GetComponent<BoxCollider2D>().offset.x;
        playerMinX += .4f; //This just makes it a little cleaner
        playerMaxX = player.transform.position.x + player.GetComponent<BoxCollider2D>().size.x + player.GetComponent<BoxCollider2D>().offset.x;
        if (playerMaxX < objectMinX) //player is to the left of the lantern
        {
            //If they are to the left and facint right
            /*if (LevelManager.playerScript.facingRight)
            {
                //Debug.Log("Is in range to grab");
                return true;
            }
            else
            {
                //Debug.Log("Facing wrong way");
                return false;
            }

        }
        if (objectMaxX < playerMinX) //player is to the right of the lantern
        {
            //If they are to the right and facing left
            if (!LevelManager.playerScript.facingRight)
            {
                //Debug.Log("Is in range to grab");
                return true;
            }
            else
            {
                //Debug.Log("Facing wrong way");
                return false;
            }*/

        }

        //If the player is under or over the lantern then it can pick up
        //Debug.Log("Is in range to grab");
        return true; // the only remaining alternative is that they are colliding
    }
}
