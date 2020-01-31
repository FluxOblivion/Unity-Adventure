using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractFire : Interactable
{
    public ParticleSystem fireParticles;
    public bool isLit = false;

    public InteractSwitch fireSwitch;

    // Start is called before the first frame update
    void Start()
    {
        fireParticles = GetComponent<ParticleSystem>();
        fireSwitch = GetComponent<InteractSwitch>();

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

        if (fireSwitch != null)
        {
            //Debug.Log("Triggered switch.");
            fireSwitch.Interact();
        }

        hasInteracted = true;
    }

    public void Interact(bool fireState)
    {
        // Problem might be here for projectile switch triggering
        if (fireState == true)
        {
            if (fireParticles.isPlaying)
            {
                return;
            } else
            {
                //Debug.Log("Fire started.");
                fireParticles.Play();
                isLit = true;
            }
        }
        else if (fireState == false)
        {
            if (!fireParticles.isPlaying)
            {
                return;
            } else
            {
                //Debug.Log("Fire stopped.");
                fireParticles.Stop();
                isLit = false;
            }
        }

        if (fireSwitch != null)
        {
            //Debug.Log("Triggered switch.");
            fireSwitch.Interact();
        }

        hasInteracted = true;
    }
}
