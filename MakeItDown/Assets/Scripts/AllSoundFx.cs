using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllSoundFx : MonoBehaviour
{
    public bool isLimitless;

    public bool isSoundOn = true;

    public bool isLimitlessBGmusicActive = false;

    public AudioClip trapBlast;
    public AudioClip ballcollision;
    public AudioClip blastSound;
    public AudioClip entryGate;
    public AudioClip playButton;
    public AudioClip otherButton;
    public AudioClip foundKey;
    public AudioClip openExitGate;
    public AudioClip levelComplete;
    public AudioClip fallenGameOver;
    public AudioClip FinalClassicFireworks;
    public AudioClip FinalBG;
    public AudioClip DiamondCollect;
    public AudioClip LimLessWallsfx;
    public AudioClip LimLessFall;
    public AudioClip UnlockLimless;


    public AudioSource playSoundHigh;
    public AudioSource playSoundLow;

    public AudioSource bgMusic;
    public AudioSource limlessBGMusic;

    public GameObject AudioOn;
    public GameObject AudioOff;
    public GameManager GM;
    public MenuManager MM;
    public LimitlessGameManager LLGM;

    void Start()
    {
        if(isSoundOn)
        {
            AudioOn.SetActive(true);
            AudioOff.SetActive(false);
            if(!isLimitless)
            {
                bgMusic.Play();
            }            
        }
        else
        {
            AudioOff.SetActive(true);
            AudioOn.SetActive(false);
            if(!isLimitless)
            {
                bgMusic.Stop();
            }            
        }
    }

    #region Only for menu scene audio control

    public void TurnOnMenuAudio()
    {
        PlayotherButton();
        AudioOff.SetActive(false);
        AudioOn.SetActive(true);
        isSoundOn = true;
        bgMusic.Play();
        MM.SaveGameMenu();
    }
    public void TurnOffMenuAudio()
    {
        PlayotherButton();
        AudioOn.SetActive(false);
        AudioOff.SetActive(true);
        isSoundOn = false;
        bgMusic.Stop();
        MM.SaveGameMenu();
    }


    #endregion

    public void TurnOnAudio()
    {
        PlayotherButton();
        AudioOff.SetActive(false);
        AudioOn.SetActive(true);        
        isSoundOn = true;
        GM.SaveThisGame();
    }
    public void TurnOffaudio()
    {
        PlayotherButton();
        AudioOn.SetActive(false);
        AudioOff.SetActive(true);
        isSoundOn = false;
        GM.SaveThisGame();
    }


    public void TurnOnLimitlessAudio()
    {
        PlayotherButton();
        AudioOff.SetActive(false);
        AudioOn.SetActive(true);
        isSoundOn = true;
        if(isLimitlessBGmusicActive)
        {
            limlessBGMusic.Play();
        }        
        LLGM.SaveLimitless();
    }
    public void TurnOffLimitlessAudio()
    {
        PlayotherButton();
        AudioOn.SetActive(false);
        AudioOff.SetActive(true);
        isSoundOn = false;
        if (isLimitlessBGmusicActive)
        {
            limlessBGMusic.Stop();
        }        
        LLGM.SaveLimitless();
    }



    public void playCollisionSound()//Constant ball collision Sound
    {
        if (isSoundOn)
        {
            playSoundLow.volume = 0.5f;
            playSoundLow.PlayOneShot(ballcollision);
        }
        
    }

    public void playBlastSound()//Ball Blast sound
    {
        if (isSoundOn)
        {
            playSoundHigh.volume = 1f;
            playSoundHigh.PlayOneShot(blastSound);
        }
        
    }

    public void CloseEntryGate()//Entry gate close sound
    {
        if (isSoundOn)
        {
            playSoundHigh.volume = 1f;
            playSoundHigh.PlayOneShot(entryGate);
        }
        
    }

    public void Play_PlayButton()//Play button sound
    {
        if (isSoundOn)
        {
            playSoundHigh.volume = 1f;
            playSoundHigh.PlayOneShot(playButton);
        }
    }

    public void PlayotherButton()//Play other button sound
    {
        if (isSoundOn)
        {
            playSoundHigh.volume = 1f;
            playSoundHigh.PlayOneShot(otherButton);
        }
        
    }

    public void PlayKeyFound()//Key found sound
    {
        if (isSoundOn)
        {
            playSoundLow.volume = 0.5f;
            playSoundLow.PlayOneShot(foundKey);
        }
        
    }

    public void PlayExitGate()//Exit gate opening sound
    {
        if (isSoundOn)
        {
            playSoundHigh.volume = 1f;
            playSoundHigh.PlayOneShot(openExitGate);
        }
        
    }

    public void PlayLevelComplete()//Level complete sound
    {
        if(isSoundOn)
        {
            playSoundLow.volume = 0.5f;
            playSoundLow.PlayOneShot(levelComplete);
        }
        
    }

    public void PlayFallenGameOver()//Game over by falling down
    {
        if(isSoundOn)
        {
            playSoundHigh.volume = 1f;
            playSoundHigh.PlayOneShot(fallenGameOver);
        }
    }

    public void PlayLimLessDiamondCollect()
    {
        if (isSoundOn)
        {
            playSoundLow.volume = 0.5f;
            playSoundLow.PlayOneShot(DiamondCollect);
        }
    }

    public void PlayLimLessFallen()
    {
        if (isSoundOn)
        {
            playSoundLow.volume = 0.5f;
            playSoundLow.PlayOneShot(LimLessFall);
        }
    }

    public void PlayFirework()
    {
        if (isSoundOn)
        {            
            playSoundHigh.volume = 1f;
            playSoundHigh.PlayOneShot(FinalClassicFireworks);
        }
    }

    public void PlayfinalBGSound()
    {
        if(isSoundOn)
        {
            playSoundLow.volume = 0.5f;
            playSoundLow.PlayOneShot(FinalBG);
        }
    }

    public void PlayUnlockLimless()
    {
        if (isSoundOn)
        {
            playSoundHigh.volume = 1f;
            playSoundHigh.PlayOneShot(UnlockLimless);
        }
    }

    public void playTrapBlast()//Ball Blast sound
    {
        if (isSoundOn)
        {
            playSoundHigh.volume = 1f;
            playSoundHigh.PlayOneShot(trapBlast);
        }

    }



}
