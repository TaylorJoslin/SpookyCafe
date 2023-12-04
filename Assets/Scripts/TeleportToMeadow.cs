using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToMeadow : MonoBehaviour
{
    public AudioClip transverse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(transverse, transform.position);
            SceneManager.LoadScene(3);
        }
    }
}
