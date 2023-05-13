using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2.0f;  // The speed at which the enemy moves
    public float moveDistance = 5.0f;  // The maximum distance the enemy will move

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingRight = true;
    private bool isReversingDirection = false;
    private float reverseDirectionDelay = 0.5f; // Delay before reversing direction

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        startPosition = transform.position;
        targetPosition = CalculateTargetPosition();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!isReversingDirection)
        {
            // Move the enemy towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Check if the enemy has reached the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                // Reverse the direction
                StartCoroutine(ReverseDirection());
            }
        }

        // Flip the sprite based on the movement direction
        if (movingRight)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private Vector3 CalculateTargetPosition()
    {
        // Calculate the target position based on the current direction
        return movingRight ? startPosition + Vector3.right * moveDistance : startPosition - Vector3.right * moveDistance;
    }

    public IEnumerator ReverseDirection()
    {
        isReversingDirection = true;

        // Wait for a delay before reversing the direction
        yield return new WaitForSeconds(reverseDirectionDelay);

        // Reverse the direction
        movingRight = !movingRight;

        // Calculate the new target position
        targetPosition = CalculateTargetPosition();

        isReversingDirection = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)

    {
        // Check if the collision object has the "Obstacle" tag
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Spike Obstacle") && !isReversingDirection)
        {
            // Reverse the direction
            StartCoroutine(ReverseDirection());
        }
    }

}