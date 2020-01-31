using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    public InteractButton button;
    public GameObject[] switchObjects;

    public InteractSwitch[] switchArray;

    void Start()
    {
        button = GetComponent<InteractButton>();
    }

    public void CheckForSolve()
    {
        int flippedSwitches = 0;

        Debug.Log("Checking for solve...");

        foreach (GameObject currentObject in switchObjects)
        {

            if (currentObject.GetComponent<InteractSwitch>().hasInteracted == true)
            {
                flippedSwitches++;
            }
        }

        //foreach (InteractSwitch currentSwitch in switchArray)
        //{

        //    if (currentSwitch.hasInteracted == true)
        //    {
        //        flippedSwitches++;
        //    }
        //}

        if (flippedSwitches == switchObjects.Length)
        {
            button.Interact();
            Debug.Log("Gate has been opened.");

        } else if (flippedSwitches > switchArray.Length)
        {
            Debug.Log("More flipped switches than switches. Something went wrong.");

        }
    }

}
