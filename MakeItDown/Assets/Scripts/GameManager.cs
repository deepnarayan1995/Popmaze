using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public SaveManager SM;

    //FinalGate open animation
    public ParticleSystem finalGateFX;


    public GameObject GOver;
    public GameObject GoverHolder;
    public GameObject Gpaused;
    public GameObject OutOfLife;
    public GameObject DiamondRewardPanel;
    public GameObject completeButtonPanel;
    public TextMeshProUGUI Rewardamount;
    public GameObject revived;
    public GameObject notenoughCoin;

    public bool isGameover = false;
    public bool isLevelComplete = false;
    public bool gamePausedAfterGameOver = false;
    public bool isOutOfLife = false;
    private bool islimUnPanelActive;
    public int rewardedDiamond;

    public GameObject WellDone;
    public GameObject CompleteHolder;

    public StarLife life;
    public AllSoundFx sound;
    public GameObject Ball;

    public Animator finalgate;

    public Animator FadeImage;


    Vector3 levComPresize, levComFinalsize;

    public GameObject LimitlessUnlockPanel;
    public GameObject LimUnPanHolder;

    [HideInInspector]
    public bool isEscapeActive;



    void Awake()
    {
        LoadThisGame();

        levComPresize.x = 1.1f;
        levComPresize.y = 1.1f;
        levComPresize.z = 1.1f;

        levComFinalsize.x = 1f;
        levComFinalsize.y = 1f;
        levComFinalsize.z = 1f;

        islimUnPanelActive = false;
        isEscapeActive = false;
    }

    void Update()
    {
        if (gamePausedAfterGameOver)
            return;

        if (Input.GetKeyDown(KeyCode.Escape) && !isGameover && !isOutOfLife && !isLevelComplete && !islimUnPanelActive)
        {
            if(isEscapeActive)
            {
                PauseGame();
            }            
        }
    }


    #region Game Saving coding

    public void SaveThisGame()
    {
        SM.Save(life, sound);
    }
    public void LoadThisGame()
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

            for(int i = 0; i < 60; i++)
            {
                life.AdlimitCounter[i] = life.mystats.AdlimitCounter[i];
            }

        }
    }


    #endregion


    #region All Button Functionalities


    IEnumerator ShowGameoverPanel()
    {
        gamePausedAfterGameOver = true;
        yield return new WaitForSeconds(1f);
        GOver.SetActive(true);
        SaveThisGame();
        LeanTween.scale(GoverHolder, levComPresize, 0.35f);
        yield return new WaitForSeconds(0.35f);
        LeanTween.scale(GoverHolder, levComFinalsize, 0.15f);

    }

    public void CloseRevived()
    {
        sound.PlayotherButton();
        life.isGameOverPanelActive = false;
        revived.SetActive(life.isGameOverPanelActive);
        SaveThisGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ContinuePlayingAgainstDiamond()
    {
        sound.PlayotherButton();
        if(life.diamonds >= 50)
        {
            life.diamonds -= 50;            
            isGameover = false;
            gamePausedAfterGameOver = false;
            StartCoroutine("CloseGoverPanel");
        }
        else
        {
            notenoughCoin.SetActive(true);
        }
    }
    IEnumerator CloseGoverPanel()
    {
        LeanTween.scale(GoverHolder, levComPresize, 0.15f);
        yield return new WaitForSeconds(0.15f);
        LeanTween.scale(GoverHolder, Vector3.zero, 0.35f);
        yield return new WaitForSeconds(0.35f);
        GOver.SetActive(false);
        Ball.SetActive(true);
    }

    public void ContinuePlayingAgainstAdd()
    {
        sound.PlayotherButton();
        GoverHolder.transform.localScale = new Vector3(0f, 0f, 0f);
        GOver.SetActive(false);
        isGameover = false;
        gamePausedAfterGameOver = false;        
        Ball.SetActive(true);
    }

    IEnumerator ShowLevelCompletePanel()
    {
        rewardedDiamond = 15;
        Rewardamount.text = rewardedDiamond.ToString();
        yield return new WaitForSeconds(1f);
        WellDone.SetActive(true);
        LeanTween.scale(CompleteHolder, levComPresize, 0.35f);
        yield return new WaitForSeconds(0.35f);
        LeanTween.scale(CompleteHolder, levComFinalsize, 0.15f);
        SaveThisGame();
    }

    public void RestartLevel()
    {
        isEscapeActive = false;
        Ball.SetActive(false);
        sound.PlayotherButton();
        Time.timeScale = 1f;
        SaveThisGame();
        StartCoroutine("RestartThisLevel");
    }
    IEnumerator RestartThisLevel()
    {
        FadeImage.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        isEscapeActive = false;
        sound.PlayotherButton();
        Gpaused.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        sound.PlayotherButton();
        Gpaused.SetActive(false);
        isEscapeActive = true;
    }

    public void LoadNextLevel()
    {
        life.diamonds += rewardedDiamond;
        isEscapeActive = false;
        SaveThisGame();
        sound.PlayotherButton();
        StartCoroutine("LoadNext");
    }
    IEnumerator LoadNext()
    {
        FadeImage.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadNextfromVideo()
    {
        StartCoroutine("LoadNext");
    }

    public void FinallyGotoHome()
    {
        life.diamonds += rewardedDiamond;
        sound.PlayotherButton();
        StartCoroutine("GotoHome");
    }

    public void GoHomeFromVideo()
    {
        StartCoroutine("GotoHome");
    }
    public void HomeButton()
    {        
        Ball.SetActive(false);
        Time.timeScale = 1f;
        isEscapeActive = false;
        sound.PlayotherButton();
        StartCoroutine("GotoHome");
    }

    IEnumerator GotoHome()
    {
        SaveThisGame();
        FadeImage.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenu");
    }

    public void CloseDiamondRewardPanel()
    {
        sound.PlayotherButton();
        life.diamonds += rewardedDiamond;
        DiamondRewardPanel.SetActive(false);
        completeButtonPanel.SetActive(true);
    }

    IEnumerator OpenFinalGate()
    {
        yield return new WaitForSeconds(0.5f);
        finalgate.SetTrigger("OpenFinalGate");
        finalGateFX.Play();
        sound.PlayExitGate();
    }


    public void OpenLimitlessUnlockedPanel()
    {
        islimUnPanelActive = true;
        LimitlessUnlockPanel.SetActive(true);
        StartCoroutine("OpenLimitless");        
    }
    IEnumerator OpenLimitless()
    {
        yield return new WaitForSeconds(0.15f);
        sound.PlayUnlockLimless();
        LeanTween.scale(LimUnPanHolder, levComPresize, 0.35f);
        yield return new WaitForSeconds(0.35f);
        LeanTween.scale(LimUnPanHolder, levComFinalsize, 0.15f);
    }


    public void CloseLimUnlockedPanel()
    {
        sound.PlayotherButton();
        StartCoroutine("CloseLim");
    }
    IEnumerator CloseLim()
    {
        LeanTween.scale(LimUnPanHolder, levComPresize, 0.15f);
        yield return new WaitForSeconds(0.15f);
        LeanTween.scale(LimUnPanHolder, Vector3.zero, 0.35f);
        yield return new WaitForSeconds(0.35f);
        LimitlessUnlockPanel.SetActive(false);        

        isLevelComplete = true;
        islimUnPanelActive = false;
        StartCoroutine("ShowLevelCompletePanel");

        life.adCounter++;
        SaveThisGame();

    }



    #endregion


    void OnApplicationQuit()
    {
        SaveThisGame();
    }

    private void OnApplicationFocus(bool focus)
    {
        if(!focus)
        {
            SaveThisGame();
        }
    }

}
