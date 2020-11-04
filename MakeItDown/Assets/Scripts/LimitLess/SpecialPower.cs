using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialPower : MonoBehaviour
{

    [HideInInspector]
    public bool isScoring;

    public Image powerFillSlider1;
    public Image powerGrid;

    public LowerShieldPlatform ShieldPlat;

    public GameObject ShieldPlatform;

    public Animator closePlatform;

    public float ActiveAlpha;
    public float DeactiveAlpha;


    bool isStartFilling;
    bool isStartEmptying;
    bool isButtonActive;

    void Start()
    {
        powerGrid.color = new Color(1, 1, 1, DeactiveAlpha);
        isStartFilling = true;
        isStartEmptying = false;
        isButtonActive = false;
    }


    void Update()
    {
        if(isScoring)
        {
            if(isStartFilling)
            {
                StartCoroutine("StartFillingLowerShieldButton");
            }
            if(isStartEmptying)
            {
                StartCoroutine("StartEmptyLowerShieldButton");
            }
            
        }
    }


    IEnumerator StartFillingLowerShieldButton()
    {
        yield return new WaitForSeconds(0.1f);
        powerFillSlider1.fillAmount += Time.deltaTime * Time.deltaTime;
        if (powerFillSlider1.fillAmount >= 1)
        {
            powerFillSlider1.fillAmount = 1;
            powerGrid.color = new Color(1, 1, 1, ActiveAlpha);
            isStartFilling = false;
            isButtonActive = true;
        }
    }

    public void ClickShieldButton()
    {
        if(isButtonActive)
        {
            ShieldPlatform.SetActive(true);
            isStartEmptying = true;
            isButtonActive = false;
            powerGrid.color = new Color(1, 1, 1, DeactiveAlpha);
        }
    }

    IEnumerator StartEmptyLowerShieldButton()
    {
        yield return new WaitForSeconds(0.1f);
        powerFillSlider1.fillAmount -= Time.deltaTime * 0.1f;
        if (powerFillSlider1.fillAmount <= 0.3f)
        {
            closePlatform.SetTrigger("Warning");
        }
        if (powerFillSlider1.fillAmount <= 0)
        {
            powerFillSlider1.fillAmount = 0;
            StartCoroutine("CloseShieldPlatform");
            isStartEmptying = false;
            isStartFilling = true;
        }
    }

    IEnumerator CloseShieldPlatform()
    {
        yield return new WaitForSeconds(0.2f);
        if(ShieldPlat.isBallChild)
        {
            ShieldPlat.PlayerBall.transform.SetParent(null);
            ShieldPlat.isBallChild = false;
        }
        ShieldPlatform.SetActive(false);
    }


}
