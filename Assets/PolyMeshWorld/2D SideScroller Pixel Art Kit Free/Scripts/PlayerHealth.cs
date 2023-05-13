using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (isDead)
            return;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            takeDamage(30);
        }
        else if (collision.gameObject.CompareTag("Spike"))
        {
            takeDamage(80);
        }
    }

    void takeDamage(int amount)
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
        transform.Rotate(Vector3.forward, -90f);
        // Show pause menu

        pauseMenu.ShowPauseMenu();
        pauseMenu.SetPlayerDead(true);
        // You can add more functionality like a game over screen, respawning, etc.
    }
}