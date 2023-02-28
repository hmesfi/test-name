using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public float speed = 3f;
    [SerializeField] private float isSussed = 10f;
    [SerializeField] private float SussedSpeed = 1f;
    private float canbeSussed;

    public Transform target;

    private void Update()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SussedSpeed <= canbeSussed)
            {
                other.gameObject.GetComponent<Player_Sus_Meter>().UpdateSus(-isSussed);
                canbeSussed = 0f;
            } else
            {
                canbeSussed += Time.deltaTime;
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
    }
}
