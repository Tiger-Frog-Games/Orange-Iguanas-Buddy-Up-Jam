using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int currentHealth;     // Currenth Health Amount
    [SerializeField] private int maxHealth;         // Max health amount for this entity
    [SerializeField] private SpriteRenderer spriteRenderer; // Reference to SpriteRenderer for damage flashing
    [SerializeField] private bool isEnemy = true;          // Flag for if attached to enemy, default to true

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Function to lower health by 1 
    public void DecreaseHealthByOne()
    {
        StartCoroutine(DamageFlash());
        currentHealth -= 1;

        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Enemy")
                //               gameObject.GetComponent<Enemy>().DetachBubbles();
                Destroy(gameObject);
            //Destroy the game object if health is at or below zero

        }
    }

    public void DecreaseHealthByFive()
    {
        StartCoroutine(DamageFlash());
        currentHealth -= 5;
        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Enemy")
                //               gameObject.GetComponent<Enemy>().DetachBubbles();
                Destroy(gameObject);
            //Destroy the game object if health is at or below zero

        }
    }


    // Function to increase health by 1
    public void IncreaseHealthByOne()
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

    // Function to increase health to max
    public void IncreaseHealthToMax()
    {
        currentHealth = maxHealth;
    }

    // Function to upgrade health to new max
    public void UpgradeMaxHealth(int newMax)
    {
        maxHealth = maxHealth + newMax;
    }

    // Getter function to return the status of current health
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    IEnumerator DamageFlash()
    {
        if (isEnemy == true)
        {
            for (int i = 0; i < 5; i++)
            {
                spriteRenderer.color = Color.white;
                spriteRenderer.color = Color.black;
                yield return new WaitForSeconds(.025f);
                spriteRenderer.color = Color.white;
            }
        }
        yield return null;
    }

}
