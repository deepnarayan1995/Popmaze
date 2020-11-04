using UnityEngine;

public class GPGAchievements : MonoBehaviour
{

    #region Classic levels achievements  variables
    [HideInInspector]
    public bool isCls5Unlocked, isCls5sent;
    [HideInInspector]
    public bool isCls10Unlocked, isCls10sent;
    [HideInInspector]
    public bool isCls20Unlocked, isCls20sent;
    [HideInInspector]
    public bool isCls30Unlocked, isCls30sent;
    [HideInInspector]
    public bool isCls40Unlocked, isCls40sent;
    [HideInInspector]
    public bool isCls50Unlocked, isCls50sent;
    [HideInInspector]
    public bool isCls60Unlocked, isCls60sent;
    #endregion

    [HideInInspector]
    public bool isLMACHUnlocked, isLMACHsent;

    #region Limitless Achievements Variables
    [HideInInspector]
    public bool is5LMDUnlocked, is5LMDsent;
    [HideInInspector]
    public bool is10LMDUnlocked, is10LMDsent;
    [HideInInspector]
    public bool is20LMDUnlocked, is20LMDsent;
    [HideInInspector]
    public bool is30LMDUnlocked, is30LMDsent;
    [HideInInspector]
    public bool is40LMDUnlocked, is40LMDsent;
    [HideInInspector]
    public bool is50LMDUnlocked, is50LMDsent;
    [HideInInspector]
    public bool is100LMDUnlocked, is100LMDsent;
    [HideInInspector]
    public bool is200LMDUnlocked, is200LMDsent;

    [HideInInspector]
    public bool is50SCOREUnlocked, is50SCOREsent;
    [HideInInspector]
    public bool is100SCOREUnlocked, is100SCOREsent;
    [HideInInspector]
    public bool is150SCOREUnlocked, is150SCOREsent;
    [HideInInspector]
    public bool is200SCOREUnlocked, is200SCOREsent;
    [HideInInspector]
    public bool is250SCOREUnlocked, is250SCOREsent;
    [HideInInspector]
    public bool is300SCOREUnlocked, is300SCOREsent;
    [HideInInspector]
    public bool is400SCOREUnlocked, is400SCOREsent;
    #endregion


    void Start()
    {
        if (Social.localUser.authenticated)
        {
            CheckInternetandSendACM();
        }
    }
    public void CheckInternetandSendACM()
    {
        //classic level Regular Achvmnts. sent to play service
        if (isCls5Unlocked)
        {
            if (!isCls5sent)
            {
                Social.ReportProgress(GPGSIds.achievement_complete_5_classic_levels, 100f, result =>
                {
                    if(result)
                    {
                        isCls5sent = true;
                    }
                    else if(!result)
                    {
                        isCls5sent = false;
                    }
                });
                
            }
        }
        if (isCls10Unlocked)
        {
            if (!isCls10sent)
            {
                Social.ReportProgress(GPGSIds.achievement_complete_10_classic_levels, 100f, result =>
                {
                    if (result)
                    {
                        isCls10sent = true;
                    }
                    else if (!result)
                    {
                        isCls10sent = false;
                    }
                });
            }
        }
        if (isCls20Unlocked)
        {
            if (!isCls20sent)
            {
                Social.ReportProgress(GPGSIds.achievement_complete_20_classic_levels, 100f, result =>
                {
                    if (result)
                    {
                        isCls20sent = true;
                    }
                    else if (!result)
                    {
                        isCls20sent = false;
                    }
                });
            }
        }
        if (isCls30Unlocked)
        {
            if (!isCls30sent)
            {
                Social.ReportProgress(GPGSIds.achievement_complete_30_classic_levels, 100f, null);
                isCls30sent = true;
            }
        }
        if (isCls40Unlocked)
        {
            if (!isCls40sent)
            {
                Social.ReportProgress(GPGSIds.achievement_complete_40_classic_levels, 100f, null);
                isCls40sent = true;
            }
        }
        if (isCls50Unlocked)
        {
            if (!isCls50sent)
            {
                Social.ReportProgress(GPGSIds.achievement_complete_50_classic_levels, 100f, null);
                isCls50sent = true;
            }
        }
        if (isCls60Unlocked)
        {
            if (!isCls60sent)
            {
                Social.ReportProgress(GPGSIds.achievement_complete_all_60_classic_levels, 100f, null);
                isCls60sent = true;
            }
        }

        //Limitless Unlocked Achvmnt. sent to play service 
        if (isLMACHUnlocked)
        {
            if (!isLMACHsent)
            {
                Social.ReportProgress(GPGSIds.achievement_unlock_limitless_category, 100f, null);
                isLMACHsent = true;
            }
        }

        //Limitless Regular Achvmnts. sent to play service
        if (is5LMDUnlocked)
        {
            if (!is5LMDsent)
            {
                Social.ReportProgress(GPGSIds.achievement_collect_5_limitless_diamonds_in_one_go, 100f, null);
                is5LMDsent = true;
            }
        }
        if (is10LMDUnlocked)
        {
            if (!is10LMDsent)
            {
                Social.ReportProgress(GPGSIds.achievement_collect_10_limitless_diamonds_in_one_go, 100f, null);
                is10LMDsent = true;
            }
        }
        if (is20LMDUnlocked)
        {
            if (!is20LMDsent)
            {
                Social.ReportProgress(GPGSIds.achievement_collect_20_limitless_diamonds_in_one_go, 100f, null);
                is20LMDsent = true;
            }
        }
        if (is30LMDUnlocked)
        {
            if (!is30LMDsent)
            {
                Social.ReportProgress(GPGSIds.achievement_collect_30_limitless_diamonds_in_one_go, 100f, null);
                is30LMDsent = true;
            }
        }
        if (is40LMDUnlocked)
        {
            if (!is40LMDsent)
            {
                Social.ReportProgress(GPGSIds.achievement_collect_40_limitless_diamonds_in_one_go, 100f, null);
                is40LMDsent = true;
            }
        }
        if (is50LMDUnlocked)
        {
            if (!is50LMDsent)
            {
                Social.ReportProgress(GPGSIds.achievement_collect_50_limitless_diamonds_in_one_go, 100f, null);
                is50LMDsent = true;
            }
        }
        if (is100LMDUnlocked)
        {
            if (!is100LMDsent)
            {
                Social.ReportProgress(GPGSIds.achievement_collect_100_limitless_diamonds_in_one_go, 100f, null);
                is100LMDsent = true;
            }
        }

        if (is50SCOREUnlocked)
        {
            if (!is50SCOREsent)
            {
                Social.ReportProgress(GPGSIds.achievement_make_50_limitless_score_in_one_go, 100f, null);
                is50SCOREsent = true;
            }
        }
        if (is100SCOREUnlocked)
        {
            if (!is100SCOREsent)
            {
                Social.ReportProgress(GPGSIds.achievement_make_100_limitless_score_in_one_go, 100f, null);
                is100SCOREsent = true;
            }
        }
        if (is150SCOREUnlocked)
        {
            if (!is150SCOREsent)
            {
                Social.ReportProgress(GPGSIds.achievement_make_150_limitless_score_in_one_go, 100f, null);
                is150SCOREsent = true;
            }
        }
        if (is200SCOREUnlocked)
        {
            if (!is200SCOREsent)
            {
                Social.ReportProgress(GPGSIds.achievement_make_200_limitless_score_in_one_go, 100f, null);
                is200SCOREsent = true;
            }
        }
        if (is250SCOREUnlocked)
        {
            if (!is250SCOREsent)
            {
                Social.ReportProgress(GPGSIds.achievement_make_250_limitless_score_in_one_go, 100f, null);
                is250SCOREsent = true;
            }
        }
        if (is300SCOREUnlocked)
        {
            if (!is300SCOREsent)
            {
                Social.ReportProgress(GPGSIds.achievement_make_300_limitless_score_in_one_go, 100f, null);
                is300SCOREsent = true;
            }
        }
        if (is400SCOREUnlocked)
        {
            if (!is400SCOREsent)
            {
                Social.ReportProgress(GPGSIds.achievement_make_400_limitless_score_in_one_go, 100f, null);
                is400SCOREsent = true;
            }
        }
    }    




    public void OpenAchievementPanel()
    {      
        Social.ShowAchievementsUI();
    }

    public void UnlockLimitlessCategory() // Unlock Limitless Catagory Achievements
    {
        isLMACHUnlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_unlock_limitless_category, 100f, null);
            isLMACHsent = true;
        }
        else
        {
            isLMACHsent = false;
        }
    }   
    
    
    #region Classic Levels Regular Achievements
    public void UnlockClassic5()
    {
        isCls5Unlocked = true;
        if(Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_complete_5_classic_levels, 100f, null);
            isCls5sent = true;
        }
        else
        {
            isCls5sent = false;
        }
        
    }
    public void UnlockClassic10()
    {
        isCls10Unlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_complete_10_classic_levels, 100f, null);
            isCls10sent = true;
        }
        else
        {
            isCls10sent = false;
        }
        
    }
    public void UnlockClassic20()
    {
        isCls20Unlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_complete_20_classic_levels, 100f, null);
            isCls20sent = true;
        }
        else
        {
            isCls20sent = false;
        }
    }
    public void UnlockClassic30()
    {
        isCls30Unlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_complete_30_classic_levels, 100f, null);
            isCls30sent = true;
        }
        else
        {
            isCls30sent = false;
        }        
    }
    public void UnlockClassic40()
    {
        isCls40Unlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_complete_40_classic_levels, 100f, null);
            isCls40sent = true;
        }
        else
        {
            isCls40sent = false;
        }
    }
    public void UnlockClassic50()
    {
        isCls50Unlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_complete_50_classic_levels, 100f, null);
            isCls50sent = true;
        }
        else
        {
            isCls50sent = false;
        }
    }
    public void UnlockAllClassic()
    {
        isCls60Unlocked = true;
        if (Social.localUser.authenticated && !isCls60sent)
        {
            Social.ReportProgress(GPGSIds.achievement_complete_all_60_classic_levels, 100f, null);
            isCls60sent = true;
        }
        else
        {
            isCls60sent = false;
        }        
    }
    #endregion

    #region Limitless Regular Achievements

    //Regular achievement for Diamonds
    public void Unlock5LMDInoneGo()
    {
        is5LMDUnlocked = true;
        if(Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_collect_5_limitless_diamonds_in_one_go, 100f, null);
            is5LMDsent = true;
        }
        else
        {
            is5LMDsent = false;
        }
    }
    public void Unlock10LMDInoneGo()
    {
        is10LMDUnlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_collect_10_limitless_diamonds_in_one_go, 100f, null);
            is10LMDsent = true;
        }
        else
        {
            is10LMDsent = false;
        }
    }
    public void Unlock20LMDInoneGo()
    {
        is20LMDUnlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_collect_20_limitless_diamonds_in_one_go, 100f, null);
            is20LMDsent = true;
        }
        else
        {
            is20LMDsent = false;
        }
    }
    public void Unlock30LMDInoneGo()
    {
        is30LMDUnlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_collect_30_limitless_diamonds_in_one_go, 100f, null);
            is30LMDsent = true;
        }
        else
        {
            is30LMDsent = false;
        }
    }
    public void Unlock40LMDInoneGo()
    {
        is40LMDUnlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_collect_40_limitless_diamonds_in_one_go, 100f, null);
            is40LMDsent = true;
        }
        else
        {
            is40LMDsent = false;
        }
    }
    public void Unlock50LMDInoneGo()
    {
        is50LMDUnlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_collect_50_limitless_diamonds_in_one_go, 100f, null);
            is50LMDsent = true;
        }
        else
        {
            is50LMDsent = false;
        }
    }
    public void Unlock100LMDInoneGo()
    {
        is100LMDUnlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_collect_100_limitless_diamonds_in_one_go, 100f, null);
            is100LMDsent = true;
        }
        else
        {
            is100LMDsent = false;
        }
    }
    public void Unlock200LMDInoneGo()
    {
        is200LMDUnlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_collect_200_limitless_diamonds_in_one_go, 100f, null);
            is200LMDsent = true;
        }
        else
        {
            is200LMDsent = false;
        }
    }


    //Regular achievement for Score
    public void Unlock50ScoreInoneGo()
    {
        is50SCOREUnlocked = true;
        if(Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_make_50_limitless_score_in_one_go, 100f, null);
            is50SCOREsent = true;
        }
        else
        {
            is50SCOREsent = false;
        }
        
    }
    public void Unlock100ScoreInoneGo()
    {
        is100SCOREUnlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_make_100_limitless_score_in_one_go, 100f, null);
            is100SCOREsent = true;
        }
        else
        {
            is100SCOREsent = false;
        }
    }
    public void Unlock150ScoreInoneGo()
    {
        is150SCOREUnlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_make_150_limitless_score_in_one_go, 100f, null);
            is150SCOREsent = true;
        }
        else
        {
            is150SCOREsent = false;
        }
    }
    public void Unlock200ScoreInoneGo()
    {
        is200SCOREUnlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_make_200_limitless_score_in_one_go, 100f, null);
            is200SCOREsent = true;
        }
        else
        {
            is200SCOREsent = false;
        }
    }
    public void Unlock250ScoreInoneGo()
    {
        is250SCOREUnlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_make_250_limitless_score_in_one_go, 100f, null);
            is250SCOREsent = true;
        }
        else
        {
            is250SCOREsent = false;
        }
    }
    public void Unlock300ScoreInoneGo()
    {
        is300SCOREUnlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_make_300_limitless_score_in_one_go, 100f, null);
            is300SCOREsent = true;
        }
        else
        {
            is300SCOREsent = false;
        }
    }
    public void Unlock400ScoreInoneGo()
    {
        is400SCOREUnlocked = true;
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_make_400_limitless_score_in_one_go, 100f, null);
            is400SCOREsent = true;
        }
        else
        {
            is400SCOREsent = false;
        }
    }

    #endregion

    

}
