using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision object has the "Obstacle" tag
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Get the EnemyMovement component attached to the enemy
            EnemyMovement enemyMovement = collision.gameObject.GetComponent<EnemyMovement>();

            // Reverse the direction of the enemy using the ReverseDirection method
            if (enemyMovement != null)
            {
                enemyMovement.ReverseDirection();
            }

            // Set the obstacle's rigidbody to kinematic
            Rigidbody2D obstacleRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (obstacleRigidbody != null)
            {
                obstacleRigidbody.bodyType = RigidbodyType2D.Kinematic;
            }
        }
    }
}
