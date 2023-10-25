using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            PlayerPrefs.DeleteAll();
        }
            

        //save
        if (Input.GetKeyDown(KeyCode.B))
        {
            
            Debug.Log("Saved " + GameManager.soulAmount + " souls!");
            //PlayerPrefs.SetString("name", PlayerName);
            PlayerPrefs.SetInt("MySouls ", GameManager.soulAmount);
        }

        //load
        if (Input.GetKeyDown(KeyCode.L)) 
        {
            GameManager.soulAmount = PlayerPrefs.GetInt("MySouls", 0);
            Debug.Log("Loaded with " + GameManager.soulAmount + " souls!");
        }
        
    }
}
