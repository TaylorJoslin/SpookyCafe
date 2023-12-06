using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomerChat : MonoBehaviour
{
    public GameObject chat;
    public GameObject questBubble,questTurnIn;
    private bool request = false;
    private bool turnin = false;

    private void Start()
    {
        chat.SetActive(false);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (!request)
        {
            chat.SetActive(true);
            request = true;
        }

        if (!turnin)
        {
            if (GameManager.soulAmount >= 10)
            {
                GameManager.instance.RemoveSoul(10);
                SceneManager.LoadScene(4);
                questBubble.SetActive(false);
                questTurnIn.SetActive(true);
                turnin = true;

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        chat.SetActive(false);
        questTurnIn.SetActive(false);
    }
}
