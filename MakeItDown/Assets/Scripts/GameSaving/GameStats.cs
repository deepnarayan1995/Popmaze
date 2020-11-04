using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameStats
{
    #region All gameplay saving

    // Variables of all game data
    public bool isMusicOn;
    public int diamonds;
    public bool isGameOverPanelActive;

    public int highScoreLL;
    public int VideoadCounter;

    public int totalLockedLevel;
    public bool isActive;

    //variables for rating panel show
    public bool isRatemeShown;
    public int ratemecounter;

    //variable for unlocking Limitless
    public int isLimUnlock;

    //variable for disabling start intro
    public bool isStartDisabled;
    public int isAdDisabled;

    public int[] AdlimitCounter = new int[60];

    #endregion


    public GameStats(StarLife life, AllSoundFx sound)
    {
        #region For all Gameplay

        isAdDisabled = life.isAdRemoved;
        isLimUnlock = life.isLimitlessUnlocked;
        diamonds = life.diamonds;
        highScoreLL = life.HighScore;
        totalLockedLevel = life.totalClassicLocked;
        isActive = life.isGameActive;
        isMusicOn = sound.isSoundOn;
        isGameOverPanelActive = life.isGameOverPanelActive;
        VideoadCounter = life.adCounter;
        isRatemeShown = life.isRatingShown;
        ratemecounter = life.rateCounter;
        isStartDisabled = life.isStartIntroDisabled;
        for(int i = 0; i < 60; i++)
        {
            AdlimitCounter[i] = life.AdlimitCounter[i];
        }

        #endregion
    }









}
