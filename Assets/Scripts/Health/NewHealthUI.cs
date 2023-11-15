using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class NewHealthUI : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;

    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

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
