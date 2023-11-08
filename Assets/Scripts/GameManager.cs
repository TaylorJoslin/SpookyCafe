using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int soulAmount = 0;
    public static GameManager instance;
    public TMP_Text soulCount;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        soulAmount = 0;
        soulCount.text = soulAmount.ToString();
    }

    private void Update()
    {
        
    }

    public void AddSoul(int amount)
    {
        soulAmount += amount;
        soulCount.text = soulAmount.ToString();
    } 

    public void RemoveSoul(int amount)
    {
        soulAmount -= amount;
        soulCount.text = soulAmount.ToString();
    }
}
