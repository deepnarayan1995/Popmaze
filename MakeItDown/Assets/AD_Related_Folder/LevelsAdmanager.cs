using System.Collections;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class LevelsAdmanager : MonoBehaviour
{
    private string APP_ID = "ca-app-pub-9335859353149603~9913303171";

    public AllSoundFx sound;

    public AdCountLimit ACL;
    public GameManager GM;
    public StarLife life;

    private RewardBasedVideoAd rewardVideoAd;

    public GameObject VideoNotAvailable;

    string VideoAdId = "ca-app-pub-9335859353149603/7853975762";

    //string testAd = "ca-app-pub-3940256099942544/5224354917";

    bool isItForContinue = false;
    bool isitForDoubleDiamond = false;
    bool isitForFinalDiamond = false;


    void Start()
    {
        #region APP publishing

        //this Should be initialised while publishing Add
        MobileAds.Initialize(APP_ID);

        #endregion
    }


    void OnEnable()
    {
        this.rewardVideoAd = RewardBasedVideoAd.Instance;
        HandleVideoAdEvents(true);
        RequestVideoAd();
    }

    void OnDisable()
    {
        HandleVideoAdEvents(false);
        GM.SaveThisGame();
    }


    void RequestVideoAd()
    {

        AdRequest videoRequest = new AdRequest.Builder().Build();

        rewardVideoAd.LoadAd(videoRequest, VideoAdId);

    }


    public void DisplayVideoOnComplete()
    {
        if(rewardVideoAd.IsLoaded())
        {
            rewardVideoAd.Show();
            isItForContinue = false;
            isitForDoubleDiamond = false;
        }
    }


    public void DisplayVideo_AD_forCont()
    {
        isItForContinue = true;
        if(rewardVideoAd.IsLoaded())
        {
            rewardVideoAd.Show();
        }
        else
        {
            StartCoroutine("VideoNotAvailablePanel");
        }
    }
    public void DisplayVideo_AD_forDoubleDiamond()
    {
        isitForDoubleDiamond = true;
        if (rewardVideoAd.IsLoaded())
        {
            rewardVideoAd.Show();
        }
        else
        {
            StartCoroutine("VideoNotAvailablePanel");
        }
    }

    public void DisplayVideo_AD_forFinalDouble()
    {
        isitForFinalDiamond = true;
        if (rewardVideoAd.IsLoaded())
        {
            rewardVideoAd.Show();
        }
        else
        {
            StartCoroutine("VideoNotAvailablePanel");
        }
    }


    IEnumerator VideoNotAvailablePanel()
    {
        VideoNotAvailable.SetActive(true);
        yield return new WaitForSeconds(2f);
        VideoNotAvailable.SetActive(false);
    }





    #region Events for video ad

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        RequestVideoAd();
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        RequestVideoAd();
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {        

        if(isItForContinue)
        {
            ACL.IncreaseAdLimitCounter();
            GM.ContinuePlayingAgainstAdd();
            isitForDoubleDiamond = false;
            isItForContinue = false;
            isitForFinalDiamond = false;
            GM.SaveThisGame();
        }
        else if(isitForDoubleDiamond)
        {
            ACL.IncreaseAdLimitCounter();
            life.diamonds += GM.rewardedDiamond * 2;            
            isitForDoubleDiamond = false;
            isItForContinue = false;
            isitForFinalDiamond = false;
            GM.LoadNextfromVideo();
            GM.SaveThisGame();
        }
        else if(isitForFinalDiamond)
        {
            ACL.IncreaseAdLimitCounter();
            life.diamonds += GM.rewardedDiamond * 2;
            isitForDoubleDiamond = false;
            isItForContinue = false;
            isitForFinalDiamond = false;
            GM.GoHomeFromVideo();
            GM.SaveThisGame();
        }
    }


    #endregion




    void HandleVideoAdEvents(bool subscribed)
    {
        if(subscribed)
        {
            // Called when an ad request failed to load.
            this.rewardVideoAd.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
            // Called when the user should be rewarded for watching a video.
            this.rewardVideoAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
            // Called when the ad is closed.
            this.rewardVideoAd.OnAdClosed += HandleRewardBasedVideoClosed;
        }
        else
        {
            // Called when an ad request failed to load.
            this.rewardVideoAd.OnAdFailedToLoad -= HandleRewardBasedVideoFailedToLoad;
            // Called when the user should be rewarded for watching a video.
            this.rewardVideoAd.OnAdRewarded -= HandleRewardBasedVideoRewarded;
            // Called when the ad is closed.
            this.rewardVideoAd.OnAdClosed -= HandleRewardBasedVideoClosed;
        }
    }







}
