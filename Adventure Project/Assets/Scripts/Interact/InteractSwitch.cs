using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSwitch : Interactable
{
    public InteractFire fire;
    SwitchManager manager;

    public GameObject attachedObject;
    
    // Start is called before the first frame update
    void Start()
    {
        fire = GetComponent<InteractFire>();
        manager = attachedObject.GetComponent<SwitchManager>();
        hasInteracted = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Interact()
    {
        //base.Interact();

        if (fire.isLit == true)
        {
            if (this.hasInteracted == false)
            {
                //Debug.Log("Fire has been lit.");
                this.hasInteracted = true;
                manager.CheckForSolve();
            }
        } else if (fire.isLit == false)
        {
            if (this.hasInteracted == true)
            {
                //Debug.Log("Fire has been snuffed out.");
                this.hasInteracted = false;
                manager.CheckForSolve();
            }
        }
    }


}
