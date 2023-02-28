using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float rayCastDistance = 10f;
    public float suspicionThreshold = 3f;
    public GameObject enemyPrefab;

    private bool playerDetected;
    private float suspicionMeter;
    private List<GameObject> enemies = new List<GameObject>();
    private float minX, maxX; // Define minX and maxX variables

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        minX = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x;
        maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
    }

    private void Update()
    {
        // Check if the player is detected
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position - transform.position, rayCastDistance);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            playerDetected = true;
            suspicionMeter += Time.deltaTime;
        }
        else
        {
            playerDetected = false;
            suspicionMeter = Mathf.Max(0f, suspicionMeter - Time.deltaTime);
        }

        // Move towards the player if detected
        if (playerDetected)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            Vector3 moveVector = new Vector3(direction.x, direction.y, 0f);
            transform.position += moveVector * moveSpeed * Time.deltaTime;
        }
        else
        {
            // Move left to right across the map
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            // If the enemy reaches the right edge of the screen, wrap around to the left side
            if (transform.position.x > maxX)
            {
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            }
        }

        // Call more enemies if suspicion level is high enough
        if (suspicionMeter >= suspicionThreshold)
        {
            int numEnemies = Mathf.FloorToInt(suspicionMeter / suspicionThreshold);
            for (int i = 0; i < numEnemies; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                enemies.Add(enemy);
            }
        }

        // Make all enemies follow the player if suspicion level is high enough
        if (enemies.Count > 0 && suspicionMeter >= suspicionThreshold)
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.position,
                    moveSpeed * Time.deltaTime);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // End game if the enemy catches the player
        if (collision.CompareTag("Player"))
        {

            Debug.Log("Game Over");
            Destroy(collision.gameObject);
        }
    }

}
