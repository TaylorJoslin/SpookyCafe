using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackArea;

    bool hasAttacked;
    public float timeBetweenAttacks;
    //public Animator attackAni;
    

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    
    
    public AudioClip AttackSound;
    
    public float KnockbackForce;


    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        
        //attackAni = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        if (Input.GetButtonDown("Fire1"))
        {

            if (!hasAttacked)
            {
                Debug.Log("PlayerATTACK");

                Attack();
                //attackAni.SetTrigger("Active");
                
                AudioSource.PlayClipAtPoint(AttackSound, transform.position);
                hasAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }

           
            
        }
        

        

    }

    private void ResetAttack()
    {
        hasAttacked = false;
    }

    private void Attack() 
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<EnemyHealth>().TakeDamage(2);
            enemy.transform.position += transform.forward * Time.deltaTime * KnockbackForce;
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
