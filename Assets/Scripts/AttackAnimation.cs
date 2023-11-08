using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    public Animator attackAni;
    bool hasAttacked;
    public float timeBetweenAttacks;

    // Start is called before the first frame update
    void Start()
    {
        attackAni = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!hasAttacked)
            {
                attackAni.SetTrigger("Active");
                hasAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }else
            {
                attackAni.SetTrigger("Idle");
            }
               
        }
       
            
    }

    private void ResetAttack()
    {
        hasAttacked = false;
    }
}
