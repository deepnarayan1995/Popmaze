using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseHealth : MonoBehaviour
{
    public StarLife life;
    public LimitlessBallCollision BallHealth;

    public Image HealthButton;

    public float ActiveAlpha;
    public float DeactiveAlpha;

    [HideInInspector]
    public bool isButtonActive;
    [HideInInspector]
    public bool isScoring;

    void Start()
    {
        HealthButton.color = new Color(1, 1, 1, DeactiveAlpha);
    }

    void Update()
    {
        if(isScoring)
        {
            if(life.diamonds >= 50 && BallHealth.currenthealth < 100)
            {
                isButtonActive = true;
                HealthButton.color = new Color(1, 1, 1, ActiveAlpha);
            }
            else
            {
                isButtonActive = false;
                HealthButton.color = new Color(1, 1, 1, DeactiveAlpha);
            }
        }
        else
        {
            isButtonActive = false;
            HealthButton.color = new Color(1, 1, 1, DeactiveAlpha);
        }
    }
}
