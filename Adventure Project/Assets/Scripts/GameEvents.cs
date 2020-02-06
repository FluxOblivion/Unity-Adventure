using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }


    // Determines what to do when a projectile hits an object (Not utilised yet)
    public event Action onProjectileCollision;
    public void ProjectileCollision(GameObject collided)
    {
        if (onProjectileCollision != null)
        {
            onProjectileCollision();
        }
    }

    // Dialogue Initiated (use to control player states!)
    public event Action onDialogueStart;
    public void DialogueStart()
    {
        if (onDialogueStart != null)
        {
            onDialogueStart();
        }
    }

    //Dialogue Ended (use to control player states!)
    public event Action onDialogueEnd;
    public void DialogueEnd()
    {
        if (onDialogueEnd != null)
        {
            onDialogueEnd();
        }
    }

    //On damage taken

    //On mana used


}
