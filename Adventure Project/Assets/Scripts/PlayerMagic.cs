using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject projectile;
    public PlayerStats stats;


    private void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (stats.playerMana <= 0)
            {
                Debug.Log("Out of mana.");
            } else
            {
                Shoot();
                stats.UseMana(5);
            }
        }
    }

    void Shoot()
    {
        // Shooting logic
        Instantiate(projectile, shootPoint.position, shootPoint.rotation);
    }
}
