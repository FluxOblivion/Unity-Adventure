using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth = 50f;
    float currentHealth;
    public float enemyArmour = 0;
    public float enemyDamage;

    public Object enemyObj;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            TakeDamage(10f);
        }

        if (currentHealth <= 0)
        {
            enemyDeath();
        }
    }

    public void TakeDamage(float damageTaken)
    {
        currentHealth -= (damageTaken - enemyArmour);
        Debug.Log(enemyObj.name + " has " + currentHealth + " health left.");

        // Play hurt animation
    }

    void enemyDeath()
    {
        // Die animation

        Object.Destroy(enemyObj, 0f);
        Debug.Log("Enemy has been slain.");
    }
}
