using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject coinPrefab;
    public int numCoins = 10;
    public float popUpForce = 5f;
    public float popUpDelay = 0.1f;
    public float boxLifetime = 3f;

    private bool isHit = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // You may want to add additional conditions to check what you're colliding with
        if (!isHit)
        {
            isHit = true;
            InvokeRepeating("PopUpCoin", 0f, popUpDelay);
            Invoke("DestroyBox", boxLifetime);
        }
    }

    private Vector3 previousCoinPosition; // Track the position of the previously spawned coin
    private bool spawnToRight = true; // Flag to alternate between left and right spawning

    private void PopUpCoin()
    {
        if (isHit && numCoins > 0)
        {
            float spawnOffset = spawnToRight ? 3f : -3.7f; // Adjust the gap between coins as desired (20cm = 0.2f)
            Vector3 spawnPosition = transform.position + new Vector3(spawnOffset, 0f, 0f);

            if (numCoins < 10)
            {
                spawnPosition = previousCoinPosition + new Vector3(spawnOffset, 0f, 0f);
            }

            GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
            Rigidbody2D coinRb = coin.GetComponent<Rigidbody2D>();
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            coinRb.AddForce(randomDirection * popUpForce, ForceMode2D.Impulse);

            previousCoinPosition = spawnPosition; // Update the previous coin position
            spawnToRight = !spawnToRight; // Toggle the spawn direction

            numCoins--;
            if (numCoins <= 0)
            {
                CancelInvoke("PopUpCoin");
            }
        }
    }



    private void DestroyBox()
    {
        if (isHit)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Handle coin collection here (e.g., increase player's coin count)
            Destroy(other.gameObject); // Destroy the coin when collected
        }
    }
}
