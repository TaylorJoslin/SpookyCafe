using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static event Action OnPlayerDamage;
    public static event Action OnPlayerDeath;

    public float health, maxHeatlh;
    public GameObject player;
    


    // Start is called before the first frame update
    void Start()
    {
        health = maxHeatlh;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        OnPlayerDamage?.Invoke();

        if (health <= 0)
        {
            health = 0;
            Debug.Log("You are Dead");
            Time.timeScale = 0;
            OnPlayerDeath?.Invoke();
            
        }
    }

    
}
