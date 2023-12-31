using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static event Action OnPlayerDamage;
    public static event Action OnPlayerDeath;

    public float health, maxHeatlh;
    public GameObject player,restartText;
    


    // Start is called before the first frame update
    void Start()
    {
        restartText.SetActive(false);
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
            restartText.SetActive(true);
            
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && health == 0) 
        {
            Destroy(GameObject.Find("Player"));
            Destroy(GameObject.Find("Canvas"));
            Destroy(GameObject.Find("EventSystem"));
            Destroy(GameObject.Find("GameManager"));
            Destroy(GameObject.Find("Virtual Camera"));
            Destroy(GameObject.Find("Main Camera"));

            SceneManager.LoadSceneAsync("StartScene(BLANK)");
            restartText.SetActive(false);
            Time.timeScale = 1;
        }
    }


}
