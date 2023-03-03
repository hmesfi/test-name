using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyInteraction : MonoBehaviour
{

    // Reference to the PlayerController script 
    private PlayerController playerController; 

    void Start()
    {
        // Get the PlayerController script from the scene
        playerController = FindObjectOfType<PlayerController>(); 
    }

    void Update()
    {
        CheckKeyRange();
    }

    void CheckKeyRange()
    {
        // Check if player is in range and facing key
        //RaycastHit hit;
        
        // Check if player presses the interact key and is looking at an interactable object
        //if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        //{
        //    playerController.PickUpKey(); 
        //}

    }



    
}

