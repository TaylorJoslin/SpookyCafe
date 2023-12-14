using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermanager : MonoBehaviour
{
    public GameObject player;


    private void Awake()
    {
        player.SetActive(false);
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
