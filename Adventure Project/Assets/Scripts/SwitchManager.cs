using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    public int doorId;
    public bool hasOpened;
    public bool stayOpen = true;

    public InteractButton button;
    //public GameObject[] switchObjects;

    public InteractSwitch[] switchObjectArray;
    public int flippedCount = 0;

    void Start()
    {
        button = GetComponent<InteractButton>();
        GameEvents.current.onSwitchTriggered += SwitchFlipped;

        foreach (InteractSwitch currentSwitch in switchObjectArray)
        {
            if (currentSwitch.hasInteracted == true)
            {
                flippedCount++;
            }
        }
    }

    public void SwitchFlipped(int id, int door)
    {
        if (hasOpened && stayOpen)
        {
            return;

        } else if (hasOpened && !stayOpen)
        {
            if (door == doorId)
            {
                if (switchObjectArray[id].hasInteracted == true)
                {
                    flippedCount++;
                }
                else
                {
                    flippedCount--;
                }

                if (flippedCount < switchObjectArray.Length)
                {
                    CheckForSolve();
                }
            }

        } else {
            if (door == doorId)
            {
                if (switchObjectArray[id].hasInteracted == true)
                {
                    flippedCount++;
                }
                else
                {
                    flippedCount--;
                }

                if (flippedCount >= switchObjectArray.Length)
                {
                    CheckForSolve();
                }
            }
        }
    }

    public void CheckForSolve()
    {
        int flippedSwitches = 0;
        //InteractSwitch currentSwitch;

        Debug.Log("Checking for solve...");

        foreach (InteractSwitch currentSwitch in switchObjectArray)
        {
            if (currentSwitch.hasInteracted == false)
            {
                /* Will only get to this point if the door has already been opened is checking
                    whether to stay open... At least thats the intent.
                 */
                Debug.Log("Not solved.");
                hasOpened = false;
                button.Interact();
                return;
            }
            else
            {
                flippedSwitches++;
            }
        }

        if (flippedSwitches == switchObjectArray.Length)
        {
            button.Interact();
            hasOpened = true;
            Debug.Log("Gate has been opened.");

        }
        else if (flippedSwitches > switchObjectArray.Length)
        {
            Debug.Log("More flipped switches than switches. Something went wrong.");
        }

        //foreach (GameObject currentObject in switchObjects)
        //{
        //    currentSwitch = currentObject.GetComponent<InteractSwitch>();
        //    if (currentSwitch.hasInteracted == false)
        //    {
        //        Debug.Log("Not solved.");
        //        return;
        //    } else
        //    {
        //        flippedSwitches++;
        //    }
        //}

        //if (flippedSwitches == switchObjects.Length)
        //{
        //    button.Interact();
        //    Debug.Log("Gate has been opened.");

        //} else if (flippedSwitches > switchObjectArray.Length)
        //{
        //    Debug.Log("More flipped switches than switches. Something went wrong.");
        //}
    }

    //public void CheckForSolve(int id)
    //{
    //    int flippedSwitches = 0;

    //    Debug.Log("Checking for solve...");

    //    foreach (GameObject currentObject in switchObjectArray)
    //    {

    //        if (currentObject.GetComponent<InteractSwitch>().hasInteracted == true)
    //        {
    //            flippedSwitches++;
    //        }
    //    }

    //    if (flippedSwitches == switchObjects.Length)
    //    {
    //        button.Interact();
    //        Debug.Log("Gate has been opened.");

    //    }
    //    else if (flippedSwitches > switchObjectArray.Length)
    //    {
    //        Debug.Log("More flipped switches than switches. Something went wrong.");

    //    }

    //}

    private void OnDestroy()
    {
        GameEvents.current.onSwitchTriggered -= SwitchFlipped;
    }

}
