using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Chest_Interaction : MonoBehaviour
{
    // TO DO:: create interactable layer


    // The distance at which the player can interact with the chest
    public float interactionDistance = 2f; 

    // checks whether or not the player is in 
    // range of opening the chest
    private bool isPlayerInRange;

    private bool isInteractable;

    // Reference to the PlayerController script 
    private PlayerController playerController; 

    void Start()
    {
        // Get the PlayerController script from the scene
        playerController = FindObjectOfType<PlayerController>(); 
    }

    void Update()
    {
        CheckChestRange();
    }

    void CheckChestRange()
    {
        // Check if player is in range and facing chest
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            isPlayerInRange = true;
            isInteractable = hit.collider.GetComponent<Interactable>() != null;
        }
        else
        {
            isPlayerInRange = false;
            isInteractable = false;
        }

        // Check if player presses the interact key and is looking at an interactable object
        if (isPlayerInRange && isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            playerController.OpenChest(); =
        }
    }

    
}

