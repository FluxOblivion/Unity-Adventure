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

    //On switch tirggered
    public event Action<int, int> onSwitchTriggered;
    public void SwitchTriggered(int id, int door)
    {
        if (onSwitchTriggered != null)
        {
            onSwitchTriggered(id, door);
        }
        //Check if switch id matches? Or do that in each Switch manager?
    }

    //Aiming state
    public event Action onAimingStart;
    public void AimingStart()
    {
        if (onAimingStart != null)
        {
            onAimingStart();
        }
    }

    //Stop aiming state
    public event Action onAimingEnd;
    public void AimingEnd()
    {
        if (onAimingEnd != null)
        {
            onAimingEnd();
        }
    }

    //Blocking state
    public event Action onBlockStart;
    public void BlockStart()
    {
        if (onBlockStart != null)
        {
            onBlockStart();
        }
    }

    public event Action onBlockEnd;
    public void BlockEnd()
    {
        if (onBlockEnd != null)
        {
            onBlockEnd();
        }
    }

    //Dialog state?

    //On damage taken

    //On mana used


}
