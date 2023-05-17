using Unity.VisualScripting;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject heartPrefab;
    public int numCoins = 2;
    public int numHearts = 1;
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
            InvokeRepeating("PopUpItem", 0f, popUpDelay);
            Invoke("DestroyBox", boxLifetime);
        }
    }

    private Vector3 previousItemPosition; // Track the position of the previously spawned item
    private bool spawnToRight = true; // Flag to alternate between left and right spawning

    private void PopUpItem()
    {
        if (isHit && (numCoins > 0 || numHearts > 0))
        {
            float spawnOffset = spawnToRight ? 0.5f : -0.2f; // Adjust the gap between items as desired (20cm = 0.2f)
            Vector3 spawnPosition = transform.position + new Vector3(spawnOffset, 0f, 0f);

            if (numCoins > 0 && numHearts > 0)
            {
                if (Random.value < 0.5f)
                {
                    SpawnCoin(spawnPosition);
                    numCoins--;
                    Debug.Log("1");
                }
                else
                {
                    SpawnHeart(spawnPosition);
                    numHearts--;
                    Debug.Log("2");
                }
            }
           

            previousItemPosition = spawnPosition; // Update the previous item position
            spawnToRight = !spawnToRight; // Toggle the spawn direction

            if (numCoins <= 0 && numHearts <= 0)
            {
                CancelInvoke("PopUpItem");
            }
        }
    }

    private void SpawnCoin(Vector3 spawnPosition)
    {
        GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D coinRb = coin.GetComponent<Rigidbody2D>();
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        coinRb.AddForce(randomDirection * popUpForce, ForceMode2D.Impulse);
    }

    private void SpawnHeart(Vector3 spawnPosition)
    {
        GameObject heart = Instantiate(heartPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D heartRb = heart.GetComponent<Rigidbody2D>();
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        heartRb.AddForce(randomDirection * popUpForce, ForceMode2D.Impulse);
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
            if (other.name.Contains("Coin"))
            {
                // Handle coin collection here (e.g., increase player's coin count)
            }
            else if (other.name.Contains("Heart"))
            {
                // Handle heart collection here
            }
        }
    }
}
