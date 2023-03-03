using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHover : MonoBehaviour
{
    public float hoverSpeed = 3f; // The speed at which the object will hover
    public float hoverDistance = 0.05f; // The distance the object will hover up and down from its starting position
    private Vector3 startPosition; // The starting position of the object

    void Start()
    {
        // Store the starting position of the object
        startPosition = transform.position; 
    }

    void Update()
    {
        // Calculate the new Y position of the object based on time and hover speed
        float newY = startPosition.y + (Mathf.Sin(Time.time * hoverSpeed) * hoverDistance);

        // Set the object's position to the new position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}





