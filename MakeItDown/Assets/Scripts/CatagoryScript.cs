using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatagoryScript : MonoBehaviour
{
    public StarLife life;
    public MenuManager GM;
    public GameObject outofLifeWritten;

    [HideInInspector]
    public bool isOutofLifeActive;

    public GameObject MainmenuCameraPosition;
    public GameObject MainMenuCanvas;
    public GameObject CatagoryCanvas;
    public GameObject ClassicLevelsCanvas;

    public GameObject UnlockLev30ofclassic;

    public AllSoundFx sound;
    public Animator FadeImage;

    private bool isEscapeActive;

    public GameObject LLUnlockedPanel;
    public GameObject LLunlockHolder;
    Vector3 presize, finalsize;

    public GameObject llLockImage;
    public GameObject notenoughDiamondPanel;

    void Awake()
    {
        isEscapeActive = true;

        presize.x = 1.1f;
        presize.y = 1.1f;
        presize.z = 1.1f;

        finalsize.x = 1f;
        finalsize.y = 1f;
        finalsize.z = 1f;

        if(life.isLimitlessUnlocked == 1)
        {
            llLockImage.SetActive(false);
        }
        else
        {
            llLockImage.SetActive(true);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isEscapeActive && 
            !life.isGameOverPanelActive && !isOutofLifeActive && GM.isEscapeActiveGM)
        {
            sound.PlayotherButton();
            Camera.main.transform.position = MainmenuCameraPosition.transform.position;
            MainMenuCanvas.SetActive(true);
            CatagoryCanvas.SetActive(false);
        }
    }

    public void LoadClassicLevelsPanel()
    {
        sound.PlayotherButton();
        ClassicLevelsCanvas.SetActive(true);
        CatagoryCanvas.SetActive(false);        
    }

    public void LoadLimitless()
    {
        sound.PlayotherButton();
        if (life.isLimitlessUnlocked == 1)
        {
            StartCoroutine("LoadLimitlessLevel");
        }
        else
        {
            ShowLimitlessLocked();
        }
    }
    IEnumerator LoadLimitlessLevel()
    {
        FadeImage.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Limitless01");
    }


    public void ShowLimitlessLocked()
    {
        sound.PlayotherButton();
        isEscapeActive = false;
        UnlockLev30ofclassic.SetActive(true);
        
    }
    public void CloseLimitlessLocked()
    {
        sound.PlayotherButton();
        UnlockLev30ofclassic.SetActive(false);
        isEscapeActive = true;
    }

    public void UnlockLimitlessWith500Diamonds()
    {
        if(life.diamonds >= 500)
        {
            sound.PlayUnlockLimless();
            life.diamonds -= 500;
            life.isLimitlessUnlocked = 1;
            GM.SaveGameMenu();
            LLUnlockedPanel.SetActive(true);
            StartCoroutine("Openllunlock");
        }
        else
        {
            sound.PlayotherButton();
            notenoughDiamondPanel.SetActive(true);
        }
    }

    public void CloseNotEnoughDiamond()
    {
        sound.PlayotherButton();
        notenoughDiamondPanel.SetActive(false);
    }
    IEnumerator Openllunlock()
    {
        yield return new WaitForSeconds(0.15f);
        sound.PlayUnlockLimless();
        LeanTween.scale(LLunlockHolder, presize, 0.35f);
        yield return new WaitForSeconds(0.35f);
        LeanTween.scale(LLunlockHolder, finalsize, 0.15f);
    }

    public void CloseLLUnlocked()
    {
        sound.PlayotherButton();
        StartCoroutine("closellUnl");
    }
    IEnumerator closellUnl()
    {
        LeanTween.scale(LLunlockHolder, presize, 0.15f);
        yield return new WaitForSeconds(0.15f);
        LeanTween.scale(LLunlockHolder, Vector3.zero, 0.35f);
        yield return new WaitForSeconds(0.35f);
        LLUnlockedPanel.SetActive(false);
        llLockImage.SetActive(false);
        UnlockLev30ofclassic.SetActive(false);
        isEscapeActive = true;
    }

}
