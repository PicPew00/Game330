using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public float dropHeartProbability = 0.5f; // Probability of the enemy dropping a heart (0.0f to 1.0f)
    public GameObject heartPrefab; // Reference to the heart prefab
    public float heartLifetime = 5f; // Lifetime of the heart before it disappears

    
   

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile") && collision.gameObject.layer != LayerMask.NameToLayer("CharacterProjectile"))
        {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            if (projectile != null)
            {
                TakeDamage(projectile.damageAmount);
                Destroy(collision.gameObject); // Destroy the projectile on collision
            }
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle enemy death here
        Debug.Log("Enemy has been defeated.");

        // Randomize whether the enemy drops a heart
        bool dropHeart = Random.value < dropHeartProbability;

        if (dropHeart)
        {
            // Spawn a heart
            GameObject spawnedHeart = Instantiate(heartPrefab, transform.position, Quaternion.identity);

            // You can add more functionality like playing death animation, giving rewards, etc.
            Destroy(spawnedHeart, heartLifetime); // Destroy the heart after a certain amount of time
        }

        Destroy(gameObject);
    }





}
