using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackArea;
    private bool attacking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    private float IndicatorAlive = 1f;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public GameObject SoulPrefab;
    public GameObject AttackRangeIndicator;
   

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
            Attack();
            AttackRangeIndicator.SetActive(true);
        }
        else 
        { 
            AttackRangeIndicator.SetActive(false); 
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }

    }

    private void Attack() 
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            Destroy(enemy.gameObject);
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
