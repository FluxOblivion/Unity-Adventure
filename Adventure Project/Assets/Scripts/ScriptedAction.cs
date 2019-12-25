using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScriptedAction
{
    public virtual void DoAction()
    {
        /* 
         * Executes this action when dialogue node initates script. Will see how method handles
         * acquiring and manipulating external objects and whatnot
         */ 
        Debug.Log("Action taken.");
    }


}
