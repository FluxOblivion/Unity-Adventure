using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class PlayerController : MonoBehaviour
{
    Camera cam;
    CharacterMovement motor;
    CharacterController controller;
    PlayerStats stats;
    Animator animator;

    Interactable focus;

    //public DialogueManager dialogueManager;
    public bool interacting = false;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<CharacterMovement>();
        controller = GetComponent<CharacterController>();
        stats = GetComponent<PlayerStats>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interacting == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (focus != null)
                {
                    //if (focus.GetComponent<InteractFire>() != null && focus.GetComponent<InteractFire>().isLit == true)
                    //{
                    //    focus.Interact();
                    //    stats.GainMana(20);
                    //} else
                    //{
                    //    focus.Interact();
                    //}

                    focus.Interact();
                }

                //Ray ray = cam.ScreenPointToRay(transform.position);
                //RaycastHit hit;

                //if (Physics.Raycast(ray, out hit, 100))
                //{
                //    // Check if we hit an interactable
                //    Interactable interactable = hit.collider.GetComponent<Interactable>();

                //    // If we did, interact with it
                //    if (interactable != null)
                //    {
                //        interactable.Interact();
                //    }
                //}
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //focus = other;
        Interactable intObject = other.GetComponent<Interactable>();

        if (intObject != null)
        {
            focus = intObject;
            Debug.Log("In range of interactable object.");
            //other.GetComponent<Material>().shader = Shader.Find("Interact highlight");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        focus = null;
        //other.GetComponent<Material>().shader = Shader.Find("Lightweight Render Pipeline/Lit");
    }

    public void ControlToggle()
    {
        //will need better management of animations later
        if (interacting == false)
        {
            interacting = true;
            motor.enabled = false;
            animator.enabled = false;
            Debug.Log("Control has been disabled.");
        }
        else
        {
            interacting = false;
            motor.enabled = true;
            animator.enabled = true;
            Debug.Log("Control has been enabled.");
        }
}

}
