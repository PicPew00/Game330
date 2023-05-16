using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float lifetime = 10f; // Lifetime of the coins before they disappear

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Handle coin collection here (e.g., increase player's coin count)
            Destroy(gameObject); // Destroy the coin when collected
        }
    }
}
