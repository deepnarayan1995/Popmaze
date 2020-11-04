using System.Collections;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class LimitlessAdManager : MonoBehaviour
{
    private string APP_ID = "ca-app-pub-9335859353149603~9913303171";

    public AllSoundFx Sound;
    public LimitlessGameManager GM;
    public StarLife life;

    //private InterstitialAd interstitialAd;

    private RewardBasedVideoAd rewardVideoAd;

    public GameObject VideonotAvailable;

    bool isForNormalScore = false;
    bool isForHighScore = false;


    string videoAd_ID = "ca-app-pub-9335859353149603/7853975762";

    //string testAd = "ca-app-pub-3940256099942544/5224354917";

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
        //HandleInterstitialAdEvents(true);
        HandleVideoAdEvents(true);
        RequestVideoAd();
        //RequestInterstitial();
    }

    void OnDisable()
    {
        //HandleInterstitialAdEvents(false);
        HandleVideoAdEvents(false);
        GM.SaveLimitless();
    }


    //requesting interstitial ad
    //void RequestInterstitial()
    //{
    //    string interstitial_ID = "ca-app-pub-3940256099942544/1033173712";

    //    interstitialAd = new InterstitialAd(interstitial_ID);

    //    AdRequest realRequest = new AdRequest.Builder().
    //        AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

    //    interstitialAd.LoadAd(realRequest);
    //}

    //requesting video ad
    void RequestVideoAd()
    {
        AdRequest realRequest = new AdRequest.Builder().Build();

        rewardVideoAd.LoadAd(realRequest, videoAd_ID);
    }


    //Display interstitial ad function
    //public void DisplayInterstitial()
    //{
    //    if (interstitialAd.IsLoaded())
    //    {
    //        interstitialAd.Show();
    //    }
        
    //}

    //Display Video Ad onGameOver
    public void DisplayVideoGover()
    {
        if (rewardVideoAd.IsLoaded())
        {
            rewardVideoAd.Show();
            isForNormalScore = false;
            isForHighScore = false;
        }
    }



    //Display video ad when normal score
    public void DisplayVideoAd_Normalscore()
    {
        Sound.PlayotherButton();
        isForNormalScore = true;
        if(rewardVideoAd.IsLoaded())
        {
            rewardVideoAd.Show();
        }
        else
        {
            StartCoroutine("ShowNoVideo");
        }
    }

    //Display video ad when High score
    public void DisplayVideoAd_HighScore()
    {
        Sound.PlayotherButton();
        isForHighScore = true;
        if (rewardVideoAd.IsLoaded())
        {
            rewardVideoAd.Show();
        }
        else
        {
            StartCoroutine("ShowNoVideo");
        }
    }



    IEnumerator ShowNoVideo()
    {
        VideonotAvailable.SetActive(true);
        yield return new WaitForSeconds(2f);
        VideonotAvailable.SetActive(false);
    }




    //#region Events for Interstitial
    ////events for interstitial

    //public void HandleOnAdLoaded(object sender, EventArgs args)
    //{
    //}

    //public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    //{
    //    RequestInterstitial();
    //}

    //public void HandleOnAdOpened(object sender, EventArgs args)
    //{
    //}

    //public void HandleOnAdClosed(object sender, EventArgs args)
    //{
    //    RequestInterstitial();
    //    if(isForNormalScore)
    //    {
    //        GM.ScorePanelNormal.SetActive(false);
    //        GM.ButtonPanelNormal.SetActive(true);
    //    }
    //    if(isForHighScore)
    //    {
    //        GM.ScorepanelHigh.SetActive(false);
    //        GM.ButtonPanelHigh.SetActive(true);
    //    }
    //    GM.SaveLimitless();
    //}

    //public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    //{
    //}

    //#endregion


    //void HandleInterstitialAdEvents(bool subscribed)
    //{
    //    if (subscribed)
    //    {
    //        // Called when an ad request has successfully loaded.
    //        interstitialAd.OnAdLoaded += HandleOnAdLoaded;
    //        // Called when an ad request failed to load.
    //        interstitialAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
    //        // Called when an ad is shown.
    //        interstitialAd.OnAdOpening += HandleOnAdOpened;
    //        // Called when the ad is closed.
    //        interstitialAd.OnAdClosed += HandleOnAdClosed;
    //        // Called when the ad click caused the user to leave the application.
    //        interstitialAd.OnAdLeavingApplication += HandleOnAdLeavingApplication;
    //    }
    //    else
    //    {
    //        // Called when an ad request has successfully loaded.
    //        interstitialAd.OnAdLoaded -= HandleOnAdLoaded;
    //        // Called when an ad request failed to load.
    //        interstitialAd.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
    //        // Called when an ad is shown.
    //        interstitialAd.OnAdOpening -= HandleOnAdOpened;
    //        // Called when the ad is closed.
    //        interstitialAd.OnAdClosed -= HandleOnAdClosed;
    //        // Called when the ad click caused the user to leave the application.
    //        interstitialAd.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
    //    }
    //}



    #region Events for Video Ad

    //events for video ad

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
        life.diamonds += life.collectedDiamond * 2;

        if(isForNormalScore)
        {
            GM.ScorePanelNormal.SetActive(false);
            GM.ButtonPanelNormal.SetActive(true);
        }
        if(isForHighScore)
        {
            GM.ScorepanelHigh.SetActive(false);
            GM.ButtonPanelHigh.SetActive(true);
        }
        GM.SaveLimitless();
    }



    #endregion



    void HandleVideoAdEvents(bool subscribed)
    {
        if (subscribed)
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
