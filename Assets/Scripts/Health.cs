using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int currentHealth;     // Currenth Health Amount
    [SerializeField] private int maxHealth;         // Max health amount for this entity

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;    
    }

    // Function to lower health by 1 
    public void DecreaseHealth()
    {
        currentHealth -= 1;
        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Enemy")
                gameObject.GetComponent<Enemy>().DetachBubbles();

            Destroy(gameObject);
            //Destroy the game object if health is at or below zero

        }
    }

    // Function to increase health by 1
    public void IncreaseHealth()
    {
        if (currentHealth >= maxHealth)
        {
            return;
        }
        else
        {
            currentHealth += 1;
        }
    }

    // Getter function to return the status of current health
    public int GetCurrentHealth()
    { 
        return currentHealth;
    }

}
