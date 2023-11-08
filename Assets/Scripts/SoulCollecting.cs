using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoulCollecting : MonoBehaviour
{

    public AudioClip pickUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           Destroy(this.gameObject);
            
            GameManager.instance.AddSoul(1);
            AudioSource.PlayClipAtPoint(pickUp, transform.position);

        }
    }


}
