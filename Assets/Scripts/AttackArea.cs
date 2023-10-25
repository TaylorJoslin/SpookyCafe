using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 3;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other);

        //if (collider.GetComponent<Health>() != null)
        //{
           // Health health = collider.GetComponent<Health>();
            //health.Damage = (damage);
        //}
    }
}
