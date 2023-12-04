using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameController : MonoBehaviour
{
    public GameObject DisplayBox;
    public GameObject PassBox;
    public GameObject WaterPrefab;

    public int QWEGen;
    public int WaitingForKey;
    public int CorrectKey;
    public int CountingDown;



    private void Update()
    {
        //generates the key to be pressed randomly
        if (WaitingForKey == 0)
        {
            QWEGen = Random.Range(1, 4);
            CountingDown = 1;
            StartCoroutine(CountDown());
            if (QWEGen == 1)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<TextMeshProUGUI>().text = "Q";
            }

            if (QWEGen == 2)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<TextMeshProUGUI>().text = "W";
            }

            if (QWEGen == 3)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<TextMeshProUGUI>().text = "E";
            }
        }
        //pressing the key and checks if its the right key
        if (QWEGen == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("QKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if (QWEGen == 2)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("WKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if (QWEGen == 3)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("EKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
    }

    IEnumerator KeyPressing()
    {
        //if right key is pressed then succeed
        QWEGen = 4;
        if (CorrectKey == 1)
        {
            CountingDown = 2;
            PassBox.GetComponent<TextMeshProUGUI>().text = "Great!";
            Instantiate(WaterPrefab, transform.position, transform.rotation);
            Instantiate(WaterPrefab, transform.position, transform.rotation);
            Instantiate(WaterPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<TextMeshProUGUI>().text = "";
            DisplayBox.GetComponent<TextMeshProUGUI>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
        //if wrong key is pressed then fail
        QWEGen = 4;
        if (CorrectKey == 2)
        {
            CountingDown = 2;
            PassBox.GetComponent<TextMeshProUGUI>().text = "Miss!!!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<TextMeshProUGUI>().text = "";
            DisplayBox.GetComponent<TextMeshProUGUI>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(5.5f);
        if (CountingDown == 1)
        {
            QWEGen = 4;
            CountingDown = 2;
            PassBox.GetComponent<TextMeshProUGUI>().text = "Miss!!!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<TextMeshProUGUI>().text = "";
            DisplayBox.GetComponent<TextMeshProUGUI>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }


}
