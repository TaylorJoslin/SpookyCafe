using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyHealth : MonoBehaviour
{
    public static event Action OnEnemyDamage;
    public static event Action OnEnemyDeath;
    public float health,maxHealth;
    public GameObject self;
    public GameObject SoulPrefab;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        OnEnemyDamage?.Invoke();

        if (health <= 0)
        {
            health = 0;
            OnEnemyDeath?.Invoke();
            Instantiate(SoulPrefab, transform.position, transform.rotation);
            Destroy(self);
            

        }
    }
}
