using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject coinPrefab; // Drag and drop the coin prefab here
    public int numCoins = 10; // Number of coins to pop up
    public float popUpForce = 5f; // Force applied to the coins when they pop up
    public float popUpDelay = 0.1f; // Delay between popping up each coin
    public float boxLifetime = 3f; // Time before the box is destroyed

    private bool isHit = false;

    private void Start()
    {
        InvokeRepeating("PopUpCoin", 0f, popUpDelay);
        Invoke("DestroyBox", boxLifetime);
    }

    private void PopUpCoin()
    {
        if (!isHit)
        {
            GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
            Rigidbody2D coinRb = coin.GetComponent<Rigidbody2D>();
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            coinRb.AddForce(randomDirection * popUpForce, ForceMode2D.Impulse);

            numCoins--;
            if (numCoins <= 0)
            {
                CancelInvoke("PopUpCoin");
            }
        }
    }

    private void DestroyBox()
    {
        if (!isHit)
        {
            Destroy(gameObject);
        }
    }
}
