using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // The speed at which the character moves
    public float rotationSpeed = 100f; // The speed at which the character rotates

    float jumpHeight = 2f; // The height of the jump
    private bool isJumping = false; // Flag for whether the character is currently jumping
    private float jumpTime = 0f; // The time the character has been jumping for
    private float jumpDuration = 0.5f; // The total duration of the character's jump
    
    // Update is called once per framex
    void Update()
    {
        // Move the character forward when the user presses the "W" key
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // Move the character backward when the user presses the "S" key
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        // Turn the character left when the user presses the "A" key
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }

        // Turn the character right when the user presses the "D" key
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        // Turn the character around when the user presses the "Q" key
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

         // Make the character jump when the user presses the spacebar
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            jumpTime = 0f;
        }

        // If the character is currently jumping
        if (isJumping)
        {
            // Calculate the height of the character's jump based on the time spent jumping
            float jumpProgress = jumpTime / jumpDuration;
            float jumpHeightOffset = jumpHeight * (1f - Mathf.Pow(jumpProgress - 1f, 2f));

            // Move the character up by the height of its jump
            transform.position += Vector3.up * jumpHeightOffset * Time.deltaTime;

            // Increment the jump time
            jumpTime += Time.deltaTime;

            // If the character has finished jumping, reset the jumping flag
            if (jumpTime >= jumpDuration)
            {
                isJumping = false;
            }
        }

        //Make the character climb a wall
    }
}

