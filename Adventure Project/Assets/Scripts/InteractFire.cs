using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractFire : Interactable
{
    public ParticleSystem fireParticles;
    public bool isLit = false;

    // Start is called before the first frame update
    void Start()
    {
        fireParticles = GetComponent<ParticleSystem>();

        if (!isLit)
        {
            fireParticles.Stop();
        }else
        {
            fireParticles.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        //base.Interact();

        if (fireParticles.isPlaying)
        {
            fireParticles.Stop();
            isLit = false;
        } else
        {
            fireParticles.Play();
            isLit = true;
        }
    }
}
