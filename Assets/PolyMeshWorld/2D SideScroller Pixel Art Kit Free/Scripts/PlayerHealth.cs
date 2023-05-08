using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public int maxHealth = 3;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void takeDamage(int amount) { 
    
      currentHealth -= amount;

        if (currentHealth <= 0) {

            Debug.Log("Death");


        }
    
    }
}
