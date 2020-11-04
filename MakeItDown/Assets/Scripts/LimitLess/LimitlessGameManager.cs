using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LimitlessGameManager : MonoBehaviour
{
    public SaveManager SM;


    public GameObject Ball;
    public GameObject GoverNormal;
    public GameObject NormalHolder;
    public GameObject GoverHighScore;
    public GameObject HighHolder;
    Vector3 presize, finalsize;
    public GameObject GPaused;
    public StarLife life;
    public AllSoundFx sound;

    [HideInInspector]
    public bool isGameover = false;

    public TextMeshProUGUI diamondText;

    public float limitless_Platform_speed = 1.5f;
    [HideInInspector]
    public float speed2, speed3, speed4, speed5, speed6, speed7, speed8, speed9, speed10;
    [HideInInspector]
    public float speed11, speed12;
    [HideInInspector]
    public bool isSecondPhaseLL;
    [HideInInspector]
    public bool isThirdPhaseLL;
    [HideInInspector]
    public bool isFourthPhaseLL;
    [HideInInspector]
    public bool isFifthPhaseLL;
    [HideInInspector]
    public bool isSixthPhaseLL;
    [HideInInspector]
    public bool isSeventhPhaseLL;
    [HideInInspector]
    public bool isEightPhaseLL;
    [HideInInspector]
    public bool isNinthPhaseLL;
    [HideInInspector]
    public bool isTenthPhaseLL;
    [HideInInspector]
    public bool is11PhaseLL;
    [HideInInspector]
    public bool is12PhaseLL;


    public GameObject ScorePanelNormal, ButtonPanelNormal;
    public GameObject ScorepanelHigh, ButtonPanelHigh;

    public Animator FadeImage;

    [HideInInspector]
    public bool isBallDestroyed = false;

    [HideInInspector]
    public bool isEscapeActive;


    void Awake()
    {
        LoadLimitlessSaved();
        isGameover = false;
        isEscapeActive = false;

        presize.x = 1.1f;
        presize.y = 1.1f;
        presize.z = 1.1f;

        finalsize.x = 1f;
        finalsize.y = 1f;
        finalsize.z = 1f;

        //for Limitless Level
        isSecondPhaseLL = isThirdPhaseLL = isFourthPhaseLL = isFifthPhaseLL = false;
        isSixthPhaseLL = isSeventhPhaseLL = isEightPhaseLL = isNinthPhaseLL = isTenthPhaseLL = false;
        is11PhaseLL = is12PhaseLL = false;
        speed2 = limitless_Platform_speed + 0.15f;
        speed3 = speed2 + 0.15f;
        speed4 = speed3 + 0.15f;
        speed5 = speed4 + 0.15f;
        speed6 = speed5 + 0.15f;
        speed7 = speed6 + 0.15f;
        speed8 = speed7 + 0.15f;
        speed9 = speed8 + 0.15f;
        speed10 = speed9 + 0.15f;
        speed11 = speed10 + 0.15f;
        speed12 = speed11 + 0.15f;
        //upto this section
    }

    void Update()
    {
        //for limitless level
        if (isSecondPhaseLL)
        {
            limitless_Platform_speed = speed2;
        }
        else if (isThirdPhaseLL)
        {
            limitless_Platform_speed = speed3;
        }
        else if (isFourthPhaseLL)
        {
            limitless_Platform_speed = speed4;
        }
        else if (isFifthPhaseLL)
        {
            limitless_Platform_speed = speed5;
        }
        else if (isSixthPhaseLL)
        {
            limitless_Platform_speed = speed6;
        }
        else if (isSeventhPhaseLL)
        {
            limitless_Platform_speed = speed7;
        }
        else if (isEightPhaseLL)
        {
            limitless_Platform_speed = speed8;
        }
        else if (isNinthPhaseLL)
        {
            limitless_Platform_speed = speed9;
        }
        else if (isTenthPhaseLL)
        {
            limitless_Platform_speed = speed10;
        }
        else if (is11PhaseLL)
        {
            limitless_Platform_speed = speed11;
        }
        else if (is12PhaseLL)
        {
            limitless_Platform_speed = speed12;
        }
        //upto this section

        if(Input.GetKeyDown(KeyCode.Escape) && !isGameover)
        {
            if(isEscapeActive)
            {
                PauseGame();
            }            
        }
    }


    public void SaveLimitless()
    {
        SM.Save(life, sound);
    }
    public void LoadLimitlessSaved()
    {
        SM.Load();

        if (life.ispathExists)
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


    public IEnumerator ShowGovernormal()
    {
        yield return new WaitForSeconds(0.5f);
        GoverNormal.SetActive(true);
        SaveLimitless();
        LeanTween.scale(NormalHolder, presize, 0.35f);
        yield return new WaitForSeconds(0.35f);
        LeanTween.scale(NormalHolder, finalsize, 0.15f);
        
    }
    public void NormalOkayButton()
    {
        sound.PlayotherButton();
        life.diamonds += life.collectedDiamond;
        diamondText.text = life.diamonds.ToString();
        ScorePanelNormal.SetActive(false);
        ButtonPanelNormal.SetActive(true);
        SaveLimitless();
    }
    public IEnumerator ShowGoverHigh()
    {
        yield return new WaitForSeconds(1f);
        GoverHighScore.SetActive(true);
        SaveLimitless();
        LeanTween.scale(HighHolder, presize, 0.35f);
        yield return new WaitForSeconds(0.35f);
        LeanTween.scale(HighHolder, finalsize, 0.15f);
    }
    public void HighOkayButton()
    {
        sound.PlayotherButton();
        life.diamonds += life.collectedDiamond;
        diamondText.text = life.diamonds.ToString();
        ScorepanelHigh.SetActive(false);
        ButtonPanelHigh.SetActive(true);
        SaveLimitless();
    }

    public void RestartButton()
    {
        if(!isBallDestroyed)
        {
            Ball.SetActive(false);
        }
        isEscapeActive = false;
        sound.PlayotherButton();
        Time.timeScale = 1f;
        StartCoroutine("RestartLevel");
    }
    IEnumerator RestartLevel()
    {
        FadeImage.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        sound.PlayotherButton();
        isEscapeActive = false;
        GPaused.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isEscapeActive = true;
        sound.PlayotherButton();
        GPaused.SetActive(false);
        
    }   

    public void HomeButton()
    {        
        if (!isBallDestroyed)
        {
            Destroy(Ball.transform.gameObject);
        }        
        isEscapeActive = false;
        sound.PlayotherButton();
        Time.timeScale = 1f;
        StartCoroutine("GotoHome");
    }
    IEnumerator GotoHome()
    {
        FadeImage.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenu");
    }





    void OnApplicationQuit()
    {
        SaveLimitless();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveLimitless();
        }
    }



    //private void OnApplicationFocus(bool focus)
    //{
    //    if (focus)
    //    {
    //        life.spentTime = TimeMaster.instance.CheckDate();

    //        if (life.totalLife >= life.maxlife)
    //        {
    //            life.totalLife = life.maxlife;
    //            SaveLimitless();
    //        }

    //        else if (life.totalLife == 0)
    //        {
    //            if (life.spentTime > life.timerLeftAt)
    //            {
    //                life.spentTime -= life.timerLeftAt;
    //                if (life.spentTime < 121)
    //                {
    //                    life.totalLife += 1;
    //                    life.timer = 121;
    //                    life.timer -= life.spentTime;
    //                    life.isTimerStop = false;
    //                }
    //                else if (life.spentTime >= 121 && life.spentTime < 241)
    //                {
    //                    life.totalLife += 2;
    //                    life.spentTime -= 120;
    //                    life.timer = 121;
    //                    life.timer -= life.spentTime;
    //                    life.isTimerStop = false;
    //                }
    //                else if (life.spentTime >= 241 && life.spentTime < 361)
    //                {
    //                    life.totalLife += 3;
    //                    life.spentTime -= 240;
    //                    life.timer = 121;
    //                    life.timer -= life.spentTime;
    //                    life.isTimerStop = false;
    //                }
    //                else if (life.spentTime >= 361 && life.spentTime < 481)
    //                {
    //                    life.totalLife += 4;
    //                    life.spentTime -= 360;
    //                    life.timer = 121;
    //                    life.timer -= life.spentTime;
    //                    life.isTimerStop = false;
    //                }
    //                else if (life.spentTime >= 481)
    //                {
    //                    life.totalLife += 5;
    //                    life.spentTime = 0;
    //                    life.isTimerStop = true;
    //                }
    //            }
    //            else if (life.spentTime < life.timerLeftAt)
    //            {
    //                life.timer = life.timerLeftAt;
    //                life.timer -= life.spentTime;
    //                life.isTimerStop = false;
    //            }
    //            SaveLimitless();
    //        }

    //        else if (life.totalLife == 1)
    //        {
    //            if (life.spentTime > life.timerLeftAt)
    //            {
    //                life.spentTime -= life.timerLeftAt;
    //                if (life.spentTime < 121)
    //                {
    //                    life.totalLife += 1;
    //                    life.timer = 121;
    //                    life.timer -= life.spentTime;
    //                    life.isTimerStop = false;
    //                }
    //                else if (life.spentTime >= 121 && life.spentTime < 241)
    //                {
    //                    life.totalLife += 2;
    //                    life.spentTime -= 120;
    //                    life.timer = 121;
    //                    life.timer -= life.spentTime;
    //                    life.isTimerStop = false;
    //                }
    //                else if (life.spentTime >= 241 && life.spentTime < 361)
    //                {
    //                    life.totalLife += 3;
    //                    life.spentTime -= 240;
    //                    life.timer = 121;
    //                    life.timer -= life.spentTime;
    //                    life.isTimerStop = false;
    //                }
    //                else if (life.spentTime >= 361)
    //                {
    //                    life.totalLife += 4;
    //                    life.spentTime = 0;
    //                    life.isTimerStop = true;
    //                }
    //            }
    //            else if (life.spentTime < life.timerLeftAt)
    //            {
    //                life.timer = life.timerLeftAt;
    //                life.timer -= life.spentTime;
    //                life.isTimerStop = false;
    //            }
    //            SaveLimitless();
    //        }

    //        else if (life.totalLife == 2)
    //        {
    //            if (life.spentTime > life.timerLeftAt)
    //            {
    //                life.spentTime -= life.timerLeftAt;
    //                if (life.spentTime < 121)
    //                {
    //                    life.totalLife += 1;
    //                    life.timer = 121;
    //                    life.timer -= life.spentTime;
    //                    life.isTimerStop = false;
    //                }
    //                else if (life.spentTime >= 121 && life.spentTime < 241)
    //                {
    //                    life.totalLife += 2;
    //                    life.spentTime -= 120;
    //                    life.timer = 121;
    //                    life.timer -= life.spentTime;
    //                    life.isTimerStop = false;
    //                }
    //                else if (life.spentTime >= 241)
    //                {
    //                    life.totalLife += 3;
    //                    life.spentTime = 0;
    //                    life.isTimerStop = true;
    //                }
    //            }
    //            else if (life.spentTime < life.timerLeftAt)
    //            {
    //                life.timer = life.timerLeftAt;
    //                life.timer -= life.spentTime;
    //                life.isTimerStop = false;
    //            }
    //            SaveLimitless();
    //        }

    //        else if (life.totalLife == 3)
    //        {
    //            if (life.spentTime > life.timerLeftAt)
    //            {
    //                life.spentTime -= life.timerLeftAt;
    //                if (life.spentTime < 121)
    //                {
    //                    life.totalLife += 1;
    //                    life.timer = 121;
    //                    life.timer -= life.spentTime;
    //                    life.isTimerStop = false;
    //                }
    //                else if (life.spentTime >= 121)
    //                {
    //                    life.totalLife += 2;
    //                    life.spentTime = 0;
    //                    life.isTimerStop = true;
    //                }
    //            }
    //            else if (life.spentTime < life.timerLeftAt)
    //            {
    //                life.timer = life.timerLeftAt;
    //                life.timer -= life.spentTime;
    //                life.isTimerStop = false;
    //            }
    //            SaveLimitless();
    //        }

    //        else if (life.totalLife == 4)
    //        {
    //            if (life.spentTime > life.timerLeftAt)
    //            {
    //                life.totalLife += 1;
    //                life.spentTime = 0;
    //                life.isTimerStop = true;
    //            }
    //            else if (life.spentTime < life.timerLeftAt)
    //            {
    //                life.timer = life.timerLeftAt;
    //                life.timer -= life.spentTime;
    //                life.isTimerStop = false;
    //            }
    //            SaveLimitless();
    //        }
    //    }
    //    else
    //    {
    //        life.timerLeftAt = life.timer;
    //        life.isExittoOpen = true;
    //        SaveLimitless();
    //        TimeMaster.instance.SaveDate();
    //    }
    //}



}
