using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int score;

    public int Score { get { return score; } } // Public getter for score

    private bool isDead = false;

    public PauseMenu pauseMenu;

    private CoinCountUI coinCountUI;

    void Start()
    {
        currentHealth = maxHealth;
        score = 0;
        coinCountUI = GameObject.Find("CoinCountUI").GetComponent<CoinCountUI>();
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
        else if (collision.gameObject.CompareTag("Heart"))
        {
            Debug.Log("Heart collision detected!");
            RestoreHealth(50); // Restore a fixed amount of health
            Destroy(collision.gameObject); // Destroy the heart object on collision
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
        else if (collision.gameObject.CompareTag("Coins"))
        {
            CollectCoin(collision.gameObject);
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

    public void CollectCoin(GameObject coin)
    {
        // Destroy the coin object
        Destroy(coin);

        // Add 10 points to the score
        score += 10;

        // Update the coin count UI
        coinCountUI.UpdateCoinCountUI();

        // Display the current coin count in the console
        Debug.Log("Current coin count: " + score);
    }



    public void RestoreHealth(int amount)
    {
        currentHealth += amount;

        // Ensure the current health doesn't exceed the maximum health
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        // You can add more functionality like displaying health UI, playing a sound effect, etc.

    }

  

}
