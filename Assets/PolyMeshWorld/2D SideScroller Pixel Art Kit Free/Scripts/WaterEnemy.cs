using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnemy : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has a PlayerHealth component
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

     
        // If the colliding object has PlayerHealth, call the Die() method
        if (playerHealth != null)
        {
            playerHealth.Die();
        }
    }
}
