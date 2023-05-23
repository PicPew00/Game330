using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public AudioClip coinSound;
    private int score;

    private void Start()
    {
        score = 0;
    }

    public void CoinInteraction(AudioSource audioSource)
    {
        score += 10;
        audioSource.PlayOneShot(coinSound);
        Destroy(this.gameObject);
    }

}
