using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HealthSystem;

public class HealthUIManager : MonoBehaviour
{
    public GameObject heartPrefab;
    public GameObject playerHealth;
    public Health pHealth;

    List<HealthSystem> hearts = new List<HealthSystem>();

    private void OnEnable()
    {
        Health.OnPlayerDamage += DrawHearts;
    }

    private void OnDisable()
    {
        Health.OnPlayerDamage -= DrawHearts;
    }

    private void Start()
    {
        DrawHearts();
        playerHealth = GameObject.FindWithTag("Player");
        
    }

    public void DrawHearts()
    {
        ClearHearts();

        //how many hearts to make total based off max health

        float maxHealthRemainder = pHealth.maxHeatlh % 2;
        int heartsToMake = (int) ((pHealth.maxHeatlh / 2) + maxHealthRemainder);
        //makes hearts
        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart(); //creates total hearted needed
        }

        for (int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(pHealth.health - (i * 2), 0, 2);
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
        }
    }



    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthSystem heartComponent = newHeart.GetComponent<HealthSystem>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }






    public void ClearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthSystem> ();
        
    }
}
