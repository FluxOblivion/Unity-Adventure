using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public int projectileDamage = 20;
    public Rigidbody rb;
    public GameObject impactEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Projectile collided with: " + other.name);

        switch (other.tag)
        {
            case "Player":
                return;
            case "Fire":
                InteractFire fire = other.GetComponent<InteractFire>();
                fire.Interact(true);
                //Debug.Log(other.name + " is lit.");
                break;
            case "Enemy":
                EnemyStats enemy = other.GetComponent<EnemyStats>();
                if (enemy != null)
                {
                    enemy.TakeDamage(projectileDamage);
                }
                Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(gameObject);
                break;
            default:
                Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(gameObject);
                break;
        }

    }
}
