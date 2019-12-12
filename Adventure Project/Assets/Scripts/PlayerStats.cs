﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float playerHealth = 100;
    public float playerArmour = 0;

    public bool damageDelay = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //playerHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            playerDeath();
        }
    }

    private IEnumerator OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.name == "DeathPlane")
        {
            //playerHealth -= 10;
            playerDeath();
            //Debug.Log("Player took 10 fall damage.");
        }


        if (hit.collider.name == "EnemyMesh(Cube)")
        {
            if (damageDelay)
            {
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                playerHealth -= (10 - playerArmour);
                Debug.Log(playerHealth + " health.");

                damageDelay = true;
                yield return new WaitForSeconds(1.5f);
                damageDelay = false;
            }
        }
    }

    void playerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}