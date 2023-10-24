using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LefttoRight : MonoBehaviour
{
    //adjust this to change speed
    public float speed = 5f;

    //adjust this to change how high it goes 
    public float length = 0.5f;

    Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }
    void Update()
    {

        //calculate what the new Y position will be
        float newX = Mathf.Sin(Time.time * speed) * length + pos.x;

        //set the object's Y to the new calculated Y
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
