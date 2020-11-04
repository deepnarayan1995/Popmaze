using System.Collections;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class ADManager : MonoBehaviour
{

    //public static ADManager instance;

    public AllSoundFx sound;

    public MenuManager MM;

    private string APP_ID = "ca-app-pub-9335859353149603~9913303171";

    //private BannerView bannerAd;

    private InterstitialAd interstitialAd;

    private RewardBasedVideoAd rewardVideoAd;

    public GameObject VideoNotAvailablePanel;

    public GameObject StarlifeRewardedPanel;

    public StarLife life;

    string videoAd_Id = "ca-app-pub-9335859353149603/7853975762";


    void Start()
    {
        #region APP publishing

        //this Should be initialised while publishing Add
        MobileAds.Initialize(APP_ID);

        #endregion

        //RequestBanner();
        //RequestInterstitial();


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
        MM.SaveGameMenu();
    }    

    //void RequestBanner()
    //{
    //    string banner_Id = "ca-app-pub-3940256099942544/6300978111";

    //    bannerAd = new BannerView(banner_Id, AdSize.SmartBanner, AdPosition.Bottom);

    //    //For Testing ~
    //    AdRequest RealRequest = new AdRequest.Builder()
    //        .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();


    //    //For Real App ~
    //    //AdRequest RealRequest = new AdRequest.Builder().Build();

    //    bannerAd.LoadAd(RealRequest);
    //}

    void RequestInterstitial()
    {
        string inter_Id = "ca-app-pub-3940256099942544/1033173712";

        interstitialAd = new InterstitialAd(inter_Id);

        //For Testing ~
        AdRequest RealRequest = new AdRequest.Builder()
            .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();


        //For Real App ~
        //AdRequest RealRequest = new AdRequest.Builder().Build();

        interstitialAd.LoadAd(RealRequest);
    }

    void RequestVideoAd()
    {

        //For Real App ~
        AdRequest RealRequest = new AdRequest.Builder().Build();

        rewardVideoAd.LoadAd(RealRequest, videoAd_Id);
    }

    //public void Display_Banner()
    //{
    //    bannerAd.Show();
    //}

    //public void Display_Interstitial()
    //{
    //    if(interstitialAd.IsLoaded())
    //    {
    //        interstitialAd.Show();
    //    }
    //}



    public void Display_Video_Ad()
    {
        sound.PlayotherButton();
        if(rewardVideoAd.IsLoaded())
        {
            rewardVideoAd.Show();
        }
        else
        {
            StartCoroutine("NoVideo");
        }
    }

    IEnumerator NoVideo()
    {
        VideoNotAvailablePanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        VideoNotAvailablePanel.SetActive(false);
    }



















    // Handling Events for intersticial ad
    #region Events for Interstitial


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
    //}

    //public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    //{
    //}
    #endregion


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


























    // handling events for rewardBasedVideoAds








    #region Events for Video Ad

    

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
        life.diamonds += 10;        
        StartCoroutine("showreward");
        MM.SaveGameMenu();
    }



    #endregion

    IEnumerator showreward()
    {
        MM.isEscapeActiveGM = false;
        StarlifeRewardedPanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        StarlifeRewardedPanel.SetActive(false);
        MM.isEscapeActiveGM = true;
    }









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
