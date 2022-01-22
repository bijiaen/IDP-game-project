using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{   
    public int maxhealth = 3;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
    }

    // Update is called once per frame
    void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            //dead
        }
    }
}
