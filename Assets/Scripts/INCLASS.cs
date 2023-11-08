using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INCLASS : MonoBehaviour
{

    public Transform PlayerTransform;
    public Rigidbody rb;

   public enum EnemyStateEnum
    {
        Idle,
        Walking,
        Attacking,
        Dead
    }

    public EnemyStateEnum enemyState = EnemyStateEnum.Idle;

    private void Update()
    {
        switch (enemyState)
        {
            case EnemyStateEnum.Idle:
                Update_Idle(); 
                break;
                case EnemyStateEnum.Attacking:
                Update_Attack(); 
                break;
                case EnemyStateEnum.Dead:
                Update_Dead();
                break;
        }
    }

    private void Update_Idle() 
    { 
        if (Physics.SphereCast(transform.position, 0.5f, PlayerTransform.position - transform.position, out RaycastHit hit))
        {
            if (hit.collider.tag != "Player") 
            {
                enemyState = EnemyStateEnum.Attacking;
            }
           
        }
    }
    private void Update_Attack()
    {
        if (Physics.SphereCast(transform.position, 0.5f, PlayerTransform.position - transform.position, out RaycastHit hit))
        {
            enemyState = EnemyStateEnum.Idle;
            //code to stop enemy
            rb.velocity *= 0.1f;
        }
        rb.AddForce((PlayerTransform.position - transform.position).normalized * 10);
    }
    private void Update_Dead()
    {

    }
}
