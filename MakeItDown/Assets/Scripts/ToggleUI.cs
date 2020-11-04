using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour
{

    public bool isEffectOn = true;

    public GameObject Handle;
    private RectTransform handleTransform;
    private float onpositionX;
    private float ofpositionX;

    public float moveSpeed;
    public float t = 0.0f;
    private bool switching = false;



    public void Awake()
    {

        handleTransform = Handle.GetComponent<RectTransform>();
        onpositionX = 44f;
        ofpositionX = -42f;
    }


    void Start()
    {
        if(isEffectOn)
        {
            handleTransform.localPosition = new Vector3(onpositionX, 0, 0);
        }
        else
        {
            handleTransform.localPosition = new Vector3(ofpositionX, 0, 0);
        }
    }

    void Update()
    {
        if(switching)
        {
            StartToggling(isEffectOn);
        }
    }

    public void Switch()
    {
        if(!switching)
        {
            switching = true;
        }
    }

    private void StartToggling(bool toggleStatus)
    {
        if(toggleStatus)
        {
            handleTransform.localPosition = SmoothlyMove(Handle, onpositionX, ofpositionX);
        }
        else
        {
            handleTransform.localPosition = SmoothlyMove(Handle, ofpositionX, onpositionX);
        }
    }

    private Vector3 SmoothlyMove(GameObject handle, float startX, float endX)
    {
        Vector3 position = new Vector3(Mathf.Lerp(startX, endX, t = t + moveSpeed * 0.05f), 0, 0);
        
        //stopping the Switching
        StopSwitching();
        return position;
    }

    void StopSwitching()
    {
        if(t > 1)
        {
            switching = false;
            t = 0;
            switch(isEffectOn)
            {
                case true:
                    isEffectOn = false;
                    //sound.isSoundOn = false;
                    break;
                case false:
                    isEffectOn = true;
                    //sound.isSoundOn = true;
                    break;
            }
        }
    }
}
