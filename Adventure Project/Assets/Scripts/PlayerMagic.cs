using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : MonoBehaviour
{
    public Transform shootPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("fire2"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Shooting logic
    }
}
