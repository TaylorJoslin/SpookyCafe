using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackArea;

    bool hasAttacked;
    public float timeBetweenAttacks;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public GameObject SoulPrefab;
    public GameObject AttackRangeIndicator;
    public AudioClip AttackSound;
    public EnemyHealth EnemyHP;
   

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        AttackRangeIndicator.SetActive(false);
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
               
                AttackRangeIndicator.SetActive(true);
                AudioSource.PlayClipAtPoint(AttackSound, transform.position);
                hasAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }

           
            
        }
        else 
        { 
            AttackRangeIndicator.SetActive(false);
            
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
            //Destroy(enemy.gameObject);
            Instantiate(SoulPrefab, enemy.transform.position, enemy.transform.rotation);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
