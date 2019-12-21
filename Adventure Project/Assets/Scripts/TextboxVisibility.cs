using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextboxVisibility : MonoBehaviour
{
    public bool visibility = false;

    CanvasGroup canvasGroup;
    

    
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void HideToggle()
    {
        if (canvasGroup.alpha == 0f)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = false;    //Stops input events
        }
        else
        {
            canvasGroup.alpha = 0f;
            canvasGroup.blocksRaycasts = true;    //Activates input events
        }
    }
}
