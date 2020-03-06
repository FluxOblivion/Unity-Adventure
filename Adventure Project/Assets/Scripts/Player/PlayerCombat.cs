using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public PlayerController controller;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackDamage = 10f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    bool isBlocking = false;

    // Update is called once per frame
    void Update()
    {
        if (!isBlocking)
        {
            if (Input.GetButtonDown("Block"))
            {
                isBlocking = true;
                animator.SetBool("isBlocking", true);
                GameEvents.current.BlockStart();
            }
            else if (Time.time >= nextAttackTime)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
        else
        {
            if (Input.GetButtonUp("Block"))
            {
                isBlocking = false;
                animator.SetBool("isBlocking", false);
                GameEvents.current.BlockEnd();
            }
        }
    }

    void Attack()
    {
        // Play attack animation
        animator.SetTrigger("Attack");
        // Detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach(Collider enemy in hitEnemies)
        {
            //Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<EnemyStats>().TakeDamage(attackDamage);

        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
