using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewHealthUI : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;

    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public GameObject  restartText;

    public Image[] hearts; 

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                if(i + 0.5 == currentHealth)
                {
                    hearts[i].sprite = halfHeart;
                }
                else
                {
                    hearts[i].sprite = fullHeart;
                }
            }else
            {
                hearts[i].sprite=emptyHeart;
            }
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("You are Dead");
            Time.timeScale = 0;
            
            restartText.SetActive(true);

        }

        if (Input.GetKeyDown(KeyCode.R) && currentHealth == 0)
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

    public void TakeDamage() 
    
    { 
    if (currentHealth > 0)
        {
            currentHealth -= 0.5f;
            
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
        }
    }
}
