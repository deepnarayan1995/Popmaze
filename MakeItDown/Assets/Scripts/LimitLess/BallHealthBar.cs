using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallHealthBar : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private float updateSpeedSeconds = 0.5f;

    public LimitlessBallCollision health;

    private void Awake()
    {
        health.OnHealthPctChanged += HandleHealthChanged;
    }

    private void HandleHealthChanged(float pct)
    {
        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct)
    {
        float prechangePct = healthBar.fillAmount;
        float elapsed = 0f;


        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            healthBar.fillAmount = Mathf.Lerp(prechangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }


        healthBar.fillAmount = pct;
    }





}
