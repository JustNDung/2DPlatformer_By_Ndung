using System;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class EntityMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float pauseDuration = 1.5f;
    [SerializeField] private float castDistance = 0.75f;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private GameObject player;

    private Rigidbody2D rb;
    public Vector2 direction;
    public bool isPaused = false;
    private Coroutine pauseCoroutine;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.left; // Initialize with an initial direction
    }

    private void Update()
    {
        if (!isPaused)
        {
            // Move the entity
            rb.linearVelocity = direction * speed;

            if (direction.x < 0)
            {
                transform.eulerAngles = Vector3.zero;
            }
            else if (direction.x > 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

            // Perform a raycast to check for obstacles
            if (Physics2D.Raycast(rb.position, direction, castDistance, obstacleLayer))
            {
                if (pauseCoroutine == null)
                {
                    pauseCoroutine = StartCoroutine(ChangeDirectionAfterPause());
                }
            }
        }
    }

    private IEnumerator ChangeDirectionAfterPause()
    {
        isPaused = true;
        rb.linearVelocity = Vector2.zero; // Stop movement
        yield return new WaitForSeconds(pauseDuration); // Wait for 1 second
        direction = -direction; // Reverse direction
        isPaused = false;

        pauseCoroutine = null;
    }

    private void OnDisable()
    {
        rb.linearVelocity = Vector2.zero;
    }

    public void UpdateDirection()
    {
        if (player != null)
        {
            // Calculate direction towards the player
            Vector2 playerPosition = player.transform.position;
            Vector2 currentPosition = rb.position;
            Vector2 newDirection = (playerPosition - currentPosition).normalized;

            // Update the direction while maintaining the current movement axis
            direction = new Vector2(newDirection.x, 0).normalized;
        }
    }
}