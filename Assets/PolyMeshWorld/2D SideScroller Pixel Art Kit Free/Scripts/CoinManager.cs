using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinManager : MonoBehaviour
{
    private int score;

    private void Start()
    {
        score = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            // Destroy the coin object
            Destroy(collision.gameObject);

            // Add 10 points to the score
            score += 10;

            // Display the current coin count in the console
            Debug.Log("Current coin count: " + score);
        }
    }





}
