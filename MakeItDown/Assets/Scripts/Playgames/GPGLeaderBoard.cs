using UnityEngine;

public class GPGLeaderBoard : MonoBehaviour
{
    [HideInInspector]
    public bool isHSsent;
    [HideInInspector]
    public bool isHighScoreremains;
    [HideInInspector]
    public int LDBhighScore;


    void Start()
    {
        if (Social.localUser.authenticated)
        {
            CheckInternetandSendLDB();
        }
    }

    public void CheckInternetandSendLDB()
    {
        if (isHighScoreremains)
        {
            if (!isHSsent)
            {
                isHighScoreremains = false;
                Social.ReportScore(LDBhighScore, GPGSIds.leaderboard_limitless_high_score, null);
                LDBhighScore = 0;
                isHSsent = true;
            }
        }
    }
   
    public void OpenLeaderBoards()
    {
        Social.ShowLeaderboardUI();
    }

    public void SetLeaderboardHighScore(int HighScore)
    {
        isHighScoreremains = true;
        if(Social.localUser.authenticated)
        {
            Social.ReportScore(HighScore, GPGSIds.leaderboard_limitless_high_score, null);
            isHSsent = true;
        }
        else
        {
            isHSsent = false;
            LDBhighScore = HighScore;
        }
        
    }

}
