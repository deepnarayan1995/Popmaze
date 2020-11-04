using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryGates : MonoBehaviour
{
    [HideInInspector]
    public bool isKey1Get, isKey2Get;
    bool isOpenGate;

    public Animator opengate1;

    public Animator opengate2;

    public Animator opengate3;

    public ParticleSystem SmallGateOpen1;

    public ParticleSystem SmallGateOpen2;

    public ParticleSystem SmallGateOpen3;

    int counter;

    void Start()
    {
        counter = 1;
        isKey1Get = false;
        isKey2Get = false;
        isOpenGate = false;
        //opengate = GetComponent<Animator>();
    }


    

    void Update()
    {
        if(isKey1Get && isKey2Get)
        {
            isOpenGate = true;
            isKey1Get = false;
            isKey2Get = false;
        }

        if(isOpenGate)
        {
            if(counter == 1)
            {
                opengate1.SetTrigger("Open");
                SmallGateOpen1.Play();                
            }
            if(counter == 2)
            {
                opengate2.SetTrigger("Open");
                SmallGateOpen2.Play();
            }
            if(counter == 3)
            {
                opengate3.SetTrigger("Open");
                SmallGateOpen3.Play();
            }
            counter++;
            isOpenGate = false;
        }

    }
}
