using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWeapon : MonoBehaviour
{
    public Animator animator;
    public GameObject weapon;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")
            || animator.GetBool("isBlocking"))
        {
            weapon.SetActive(true);
        } else
        {
            weapon.SetActive(false);
        }
    }
}
