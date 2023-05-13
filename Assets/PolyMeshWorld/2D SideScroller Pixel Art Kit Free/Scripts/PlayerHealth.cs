using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private bool isDead = false;

    public PauseMenu pauseMenu;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(30);
        }
        else if (collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Spike Obstacle"))
        {
            TakeDamage(80);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            if (projectile != null)
            {
                TakeDamage(projectile.damageAmount);
                Destroy(projectile.gameObject); // Destroy the projectile on collision
            }
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        // Handle player death here
        Debug.Log("Player has died.");
        transform.Rotate(Vector3.forward, 90f);
        // Show pause menu
        pauseMenu.ShowPauseMenu();
        pauseMenu.SetPlayerDead(true);
        // You can add more functionality like a game over screen, respawning, etc.
    }
}
