using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public GameObject target;
    public float speed = 2f;   
    public Rigidbody rb;

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    void FollowPlayer()
    {       
        Vector3 pos = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        rb.MovePosition(pos);
        
    }

    private void OnTriggerStay(Collider player)
    {

        
        if (player.tag == "Player")
        {
            FollowPlayer();
        }
    }
}
