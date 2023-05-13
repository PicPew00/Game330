using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

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

        // Check if the script is being called
        Debug.Log("Die() method called.");

        // You can add more functionality like playing death animation, giving rewards, etc.
        Destroy(gameObject);
    }

}
