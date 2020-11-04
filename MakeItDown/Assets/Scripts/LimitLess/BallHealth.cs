using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BallHealth : MonoBehaviour
{

    [SerializeField]
    private int maxhealth = 100;
    private int currenthealth;

    public event Action<float> OnHealthPctChanged = delegate { };

    private void OnEnable()
    {
        currenthealth = maxhealth;
    }

    public void DecreaseHealth(int amount)
    {
        currenthealth += amount;

        float currentHealthPct = (float)currenthealth / (float)maxhealth;
        OnHealthPctChanged(currentHealthPct);
    }

    void Update()
    {
        
    }
}
