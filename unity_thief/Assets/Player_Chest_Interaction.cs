using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Chest_Interaction : MonoBehaviour
{
    // The distance at which the player can interact with the chest
    public float interactionDistance = 2f; 

    // checks whether or not the player is in 
    // range of opening the chest
    private bool isPlayerInRange = false;

    // if the player is in range pf chest
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position)
            <= interactionDistance)
        {
            isPlayerInRange = true;
        }
        else
        {
            isPlayerInRange = false;
        }
        
        // check if the chest can be interacted with
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        // Open the chest and give the player its contents
        Debug.Log("still to be implemented");
    }

    
}

