using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerChat : MonoBehaviour
{
    public GameObject chat;
    public GameObject questBubble,questTurnIn;

    private void Start()
    {
        chat.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {

        if (GameManager.soulAmount >= 10)
        {
            GameManager.instance.RemoveSoul(10);
            questBubble.SetActive(false);
            questTurnIn.SetActive(true);
            chat.SetActive(false);
        }else
        {
            chat.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        chat.SetActive(false);
        questTurnIn.SetActive(false);
    }
}
