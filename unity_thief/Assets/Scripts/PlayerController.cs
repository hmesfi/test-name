using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f; // The speed at which the character moves
    private Vector3 change; // player movement direction
    private Rigidbody2D rb2d;
    private Animator anim;
    private Renderer rend;
    float jumpHeight = 2f; // The height of the jump
    private bool isJumping = false; // Flag for whether the character is currently jumping
    private float jumpTime = 0f; // The time the character has been jumping for
    private float jumpDuration = 0.5f; // The total duration of the character's jump
    
    void Start () 
    {
        anim = GetComponentInChildren<Animator>();
        rend = GetComponentInChildren<Renderer> ();
        rb2d = GetComponent<Rigidbody2D>();
        anim.SetBool("Walk", false);
        Debug.Log("setBool to false");
        
    }

    void OpenChest()
    {
        Debug.Log("open chest");
    }

    // Update is called once per framex
    void Update()
    {
        change = Vector3.zero;

        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();

        if (Input.GetAxis ("Horizontal") > 0)
        {
            Debug.Log("Moving right!");
            Vector3 newScale = transform.localScale;
            newScale.x = 1.0f;
            transform.localScale = newScale;
        }
        else if (Input.GetAxis ("Horizontal") < 0){
                Debug.Log("Moving left!");
                Vector3 newScale =transform.localScale;
                newScale.x = -1.0f;
                transform.localScale = newScale;
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

    }

    void UpdateAnimationAndMove() {

        change = Vector3.zero;
        change.x = Input.GetAxis("Horizontal");
        change.y = Input.GetAxis("Vertical");

        if (change != Vector3.zero) {
            rb2d.MovePosition(transform.position + change * moveSpeed * Time.deltaTime);
            anim.SetBool("Walk", true);
            Debug.Log("Walking activated");
        } else {
            anim.SetBool("Walk", false);
        }
    }
}

