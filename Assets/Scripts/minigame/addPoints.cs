using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class addPoints : MonoBehaviour
{
   
    public GameObject winText;

    private void Start()
    {
        winText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            winText.SetActive(true);
            SceneManager.LoadScene(1);
        }
    }
}
