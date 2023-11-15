using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addPoints : MonoBehaviour
{
    private PointManager points;
   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cup")
        {
            
        }
    }
}
