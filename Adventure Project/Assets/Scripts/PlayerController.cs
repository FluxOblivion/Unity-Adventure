using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class PlayerController : MonoBehaviour
{
    Camera cam;
    CharacterMovement motor;
    CharacterController controller;

    Interactable focus;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<CharacterMovement>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (focus != null)
            {
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

    private void OnTriggerEnter(Collider other)
    {
        //focus = other;
        Interactable intObject = other.GetComponent<Interactable>();

        if (intObject != null)
        {
            focus = intObject;
            Debug.Log("In range of interactable object.");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        focus = null;
    }

}
