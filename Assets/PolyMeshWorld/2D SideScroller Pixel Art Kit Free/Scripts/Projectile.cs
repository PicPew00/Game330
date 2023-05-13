using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damageAmount = 30;
    public GameObject character; // Reference to the character game object

    private void Start()
    {
        // Get a reference to the character game object
        character = GameObject.FindGameObjectWithTag("Player");

        // Destroy the projectile after 3 seconds
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the projectile collides with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }

            // Destroy the projectile after hitting an enemy
            Destroy(gameObject);
        }
        else if (collision.gameObject == character) // Check if the collision is with the character
        {
            // Ignore collision with the character and do nothing
        }
    }
}
