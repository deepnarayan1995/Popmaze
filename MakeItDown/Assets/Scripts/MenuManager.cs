using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public SaveManager SM;


    public StarLife life;
    public AllSoundFx sound;
    public ClassicLevelScript cls;
    public CatagoryScript cts;


    public GameObject RemoveadButton;

    public TextMeshProUGUI TimerUp;
    public GameObject MenuTimerFull;
    public GameObject MenuTimerCountDown;

    public GameObject DiamondDemo;
    public GameObject DiamondDemoHolder;

    public bool isEscapeActiveGM;
    Vector3 presize, finalsize;

    

    void Awake()
    {
        LoadGameMenu();
    }

    void Start()
    {
        if (life.isAdRemoved == 1)
        {
            RemoveadButton.SetActive(false);
        }
        else if (life.isAdRemoved == 0)
        {
            RemoveadButton.SetActive(true);
        }


        presize.x = 1.1f;
        presize.y = 1.1f;
        presize.z = 1.1f;

        finalsize.x = 1f;
        finalsize.y = 1f;
        finalsize.z = 1f;

        isEscapeActiveGM = true;
    }




    public void SaveGameMenu()
    {
        SM.Save(life, sound);
    }
    public void LoadGameMenu()
    {
        SM.Load();

        if(life.ispathExists)
        {            
            life.isAdRemoved = life.mystats.isAdDisabled;
            life.diamonds = life.mystats.diamonds;
            sound.isSoundOn = life.mystats.isMusicOn;
            life.isGameOverPanelActive = life.mystats.isGameOverPanelActive;
            life.HighScore = life.mystats.highScoreLL;
            life.adCounter = life.mystats.VideoadCounter;
            life.totalClassicLocked = life.mystats.totalLockedLevel;
            life.isGameActive = life.mystats.isActive;
            life.isRatingShown = life.mystats.isRatemeShown;
            life.rateCounter = life.mystats.ratemecounter;
            life.isLimitlessUnlocked = life.mystats.isLimUnlock;
            life.isStartIntroDisabled = life.mystats.isStartDisabled;

            for (int i = 0; i < 60; i++)
            {
                life.AdlimitCounter[i] = life.mystats.AdlimitCounter[i];
            }

        }
    }



    //public void CloseOutOfLifePanel()
    //{
    //    sound.PlayotherButton();
    //    OutofLifePanel.SetActive(false);
    //    cls.isoutoflifeActive = false;
    //    cts.isOutofLifeActive = false;
    //}

    //public void CloseRewardPanel()
    //{
    //    sound.PlayotherButton();
    //    life.isGameOverPanelActive = false;
    //    cls.isoutoflifeActive = false;
    //    RewardLifePanel.SetActive(life.isGameOverPanelActive);
    //    SaveGameMenu();
    //    Debug.Log(cls.isoutoflifeActive);
    //    Debug.Log(life.isGameOverPanelActive);
    //}

    ////For StarLife demonstration
    //public void OpenStarLifeDemo()
    //{
    //    sound.PlayotherButton();
    //    StarLifeDemo.SetActive(true);
    //    isEscapeActiveGM = false;
    //    StartCoroutine("openstarDemo");
    //}
    //IEnumerator openstarDemo()
    //{
    //    LeanTween.scale(StarDemoHolder, presize, 0.35f);
    //    yield return new WaitForSeconds(0.35f);
    //    LeanTween.scale(StarDemoHolder, finalsize, 0.15f);
    //}

    //public void CloseStarLifeDemo()
    //{
    //    sound.PlayotherButton();
    //    StartCoroutine("closestarDemo");
    //}
    //IEnumerator closestarDemo()
    //{
    //    LeanTween.scale(StarDemoHolder, presize, 0.15f);
    //    yield return new WaitForSeconds(0.15f);
    //    LeanTween.scale(StarDemoHolder, Vector3.zero, 0.35f);
    //    yield return new WaitForSeconds(0.35f);
    //    StarLifeDemo.SetActive(false);
    //    isEscapeActiveGM = true;
    //}

    //For Diamonds Demonstration
    public void OpenDiamondDemo()
    {
        sound.PlayotherButton();
        DiamondDemo.SetActive(true);
        isEscapeActiveGM = false;
        StartCoroutine("opendDemo");
    }
    IEnumerator opendDemo()
    {
        LeanTween.scale(DiamondDemoHolder, presize, 0.35f);
        yield return new WaitForSeconds(0.35f);
        LeanTween.scale(DiamondDemoHolder, finalsize, 0.15f);
    }
       
    public void CloseDiamondDemo()
    {
        sound.PlayotherButton();
        StartCoroutine("closedDemo");
    }
    IEnumerator closedDemo()
    {
        LeanTween.scale(DiamondDemoHolder, presize, 0.15f);
        yield return new WaitForSeconds(0.15f);
        LeanTween.scale(DiamondDemoHolder, Vector3.zero, 0.35f);
        yield return new WaitForSeconds(0.35f);
        DiamondDemo.SetActive(false);
        isEscapeActiveGM = true;
    }   


    void OnApplicationQuit()
    {
        SaveGameMenu();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveGameMenu();
        }
    }






}
