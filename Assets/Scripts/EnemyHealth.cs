using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static event Action OnEnemyDamage;
    public static float health,maxHealth;
    public GameObject self;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        OnEnemyDamage?.Invoke();

        if (health <= 0)
        {
            health = 0;
            
           Destroy(self);
            

        }
    }
}
