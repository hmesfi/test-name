using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MafiaBossController : MonoBehaviour
{
    // The speed at which the mafia boss moves
    public float speed = 5f; 
    // The x-coordinate of the end point of the mafia boss's movement
    public float endX = 10f; 
    // The x-coordinate of the start point of the mafia boss's movement
    public float startX = -10f; 
    // The distance between the start and end points
    public float moveDistance = 20f;

    // The time the mafia boss pauses before moving back
    public float pauseTime = 1.5f;
    // Timer for pausing before moving back
    private float timer; 
    // Flag for whether the mafia boss is currently moving forward
    private bool movingForward = true;

    [SerializeField] private float isSussed = 10f;
    [SerializeField] private float SussedSpeed = 1f;
    private float canbeSussed;

    private Transform target;

    void Start(){
        target = GameObject.FindWithTag("Player").transform;

    }




    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }

        if (movingForward)
        {
            // Move the mafia boss forward until it reaches the end point
            if (transform.position.x < endX)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                // Pause for a short time before moving back
                timer += Time.deltaTime;
                if (timer >= pauseTime)
                {
                    timer = 0f;
                    movingForward = false;
                }
            }
        }
        else
        {
            // Move the mafia boss back until it reaches the start point
            if (transform.position.x > startX)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {
                // Pause for a short time before moving forward again
                timer += Time.deltaTime;
                if (timer >= pauseTime)
                {
                    timer = 0f;
                    movingForward = true;
                }
            }
        }
    }

    // private void OnCollisionStay2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Player")
    //     {
    //         if (SussedSpeed <= canbeSussed)
    //         {
    //             other.gameObject.GetComponent<Player_Sus_Meter>().UpdateSus(-isSussed);
    //             canbeSussed = 0f;
    //         }
    //         else
    //         {
    //             canbeSussed += Time.deltaTime;
    //         }

    //     }
    // }
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.tag == "Player")
    //     {
    //         target = other.transform;
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.gameObject.tag == "Player")
    //     {
    //         target = null;
    //     }
    // }
}
