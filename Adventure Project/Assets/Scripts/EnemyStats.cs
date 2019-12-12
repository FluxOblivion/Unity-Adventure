using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float enemyHealth = 50f;
    public float enemyArmour = 0;
    public float enemyDamage;

    public Object enemyObj;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            enemyHealth -= (10f - enemyArmour);
            Debug.Log(enemyHealth + " health left.");
        }

        if (enemyHealth <= 0)
        {
            enemyDeath();
        }
    }

    void enemyDeath()
    {
        Object.Destroy(enemyObj, 0f);
        Debug.Log("Enemy has been slain.");
    }
}
