using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimToggle : MonoBehaviour
{
    public GameObject pointer;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onAimingStart += EnablePointer;
        GameEvents.current.onAimingEnd += DisablePointer;

        DisablePointer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnablePointer()
    {
        pointer.SetActive(true);
    }

    public void DisablePointer()
    {
        pointer.SetActive(false);
    }

    private void OnDestroy()
    {
        GameEvents.current.onAimingStart -= EnablePointer;
        GameEvents.current.onAimingEnd -= DisablePointer;
    }
}
