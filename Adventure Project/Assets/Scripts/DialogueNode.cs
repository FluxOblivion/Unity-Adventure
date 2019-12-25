using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueNode
{
    public Texture characterImage;
    public string name;

    [TextArea(3, 10)]
    public string sentence;

    public bool doAction = false;

    public void DialogueAction ()
    {
        // Do dialogue action when reaching this node if doAction is true.
    }


}
