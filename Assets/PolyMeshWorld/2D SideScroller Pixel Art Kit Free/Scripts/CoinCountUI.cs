using UnityEngine;
using UnityEngine.UI;

public class CoinCountUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Text coinCountText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCoinCountUI();
    }

    // Update the coin count UI with the current coin count
    public void UpdateCoinCountUI()
    {
        coinCountText.text = "Coins: " + playerHealth.score.ToString();
    }
}
