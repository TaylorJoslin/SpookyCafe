using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addPoints : MonoBehaviour
{
    private PointManager points;
   

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cup")
        {
            PointManager.Score++;
        }
    }
}
