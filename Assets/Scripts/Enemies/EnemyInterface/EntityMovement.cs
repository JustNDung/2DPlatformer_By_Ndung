using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public float speed = 1f;
    public LayerMask obstacleLayer;

    private Rigidbody2D rb;
    private Vector2 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Initialize with an initial direction
        direction = Vector2.left;
    }

    private void Update()
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
        if (rb.Raycast(direction, 0.75f, obstacleLayer))
        {
            // Reverse direction if an obstacle is detected
            direction = -direction;
        }
    }
}