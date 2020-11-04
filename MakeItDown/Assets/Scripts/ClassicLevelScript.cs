using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassicLevelScript : MonoBehaviour
{
    public MenuManager GM;
    public StarLife life;
    public GameObject outOfLifeWritten;

    public GameObject CatagoryCanvas;
    public GameObject ClassicLevelsCanvas;

    bool[] isLevelActive = new bool[60];

    public AllSoundFx sound;
    public GameObject[] levelIcons;

    public GameObject[] lockedImage;
    public GameObject[] levelNumeric;
    public GameObject[] ActiveImages;

    int totalLocked;

    public GameObject unlockPreviousPanel;

    public Animator FadeImage;

    private bool isEscapeActive;

    //[HideInInspector]
    //public bool isoutoflifeActive;


    void Awake()
    {
        isEscapeActive = true;

        for(int i = 0; i < ActiveImages.Length; i++)
        {
            ActiveImages[i].SetActive(false);
        }
    }

    void Start()
    {
        totalLocked = life.totalClassicLocked;
        Debug.Log("TotalLocked: " + totalLocked);        

        for(int i = 0; i < 60; i++)
        {
            isLevelActive[i] = true;
        }
        for(int i = 0; i < 59; i++)
        {
            lockedImage[i].SetActive(false);
            levelNumeric[i].SetActive(true);
        }

        for (int i = 1; i <= totalLocked; i++)
        {
            isLevelActive[60 - i] = false;
            lockedImage[59 - i].SetActive(true);
            levelNumeric[59 - i].SetActive(false);
        }

        ActiveImages[59 - totalLocked].SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isEscapeActive && 
            !life.isGameOverPanelActive && GM.isEscapeActiveGM)
        {
            sound.PlayotherButton();
            CatagoryCanvas.SetActive(true);
            ClassicLevelsCanvas.SetActive(false);            
        }
    }

    public void LoadLevel(int levelnumber)
    {
        sound.PlayotherButton();
        if (isLevelActive[levelnumber - 1])
        {
            StartCoroutine(LoadLevelWait(levelnumber));
        }
        else
        {
            StartCoroutine("ShowUnlockPreviousPanel");
        }
        
    }


    IEnumerator LoadLevelWait(int levelnumber)
    {
        LeanTween.rotateZ(levelIcons[levelnumber - 1], -90, 0.2f);
        yield return new WaitForSeconds(0.2f);
        LeanTween.rotateZ(levelIcons[levelnumber - 1], 0, 0.2f);
        yield return new WaitForSeconds(0.2f);
        FadeImage.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1 + levelnumber);
    }

    IEnumerator ShowUnlockPreviousPanel()
    {
        isEscapeActive = false;
        unlockPreviousPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        unlockPreviousPanel.SetActive(false);
        isEscapeActive = true;
    }

}
