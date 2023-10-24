using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulCollecting : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Soul")
        {
           Destroy(this.gameObject);
            GameManager.soulAmount++;
            
        }
    }


}
