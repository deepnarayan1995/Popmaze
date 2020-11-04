using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SureToExitScript : MonoBehaviour
{

    private string ShareURL = "https://play.google.com/store/apps/details?id=com.techniphics.popmaze";

    public AllSoundFx sound;
    public StarLife life;
    public MenuManager GM;

    private bool isRatingpanelShown;
    [HideInInspector]
    public int rateshowCounter;

    //exit panels
    public GameObject ExitPanelHolder;
    public GameObject exitPanel;

    //rating Panels
    public GameObject RatingPanel;
    public GameObject RatingPHolder;

    //About us panels
    public GameObject AboutUsPanel;
    public GameObject AboutHolder;

    //Buying panels
    public GameObject BuyingPanel;
    public GameObject BpanelHolder;


    Vector3 presize, finalsize;
    Vector3 buyingPreSize, buyingFinalSize;

    private bool isExitpanelActive = false;
    private bool isEscapeActive;

    void Start()
    {
        presize.x = 1f;
        presize.y = 1f;
        presize.z = 1f;

        finalsize.x = 0.9f;
        finalsize.y = 0.9f;
        finalsize.z = 0.9f;

        buyingPreSize.x = 1.1f;
        buyingPreSize.y = 1.1f;
        buyingPreSize.z = 1.1f;

        buyingFinalSize.x = 1f;
        buyingFinalSize.y = 1f;
        buyingFinalSize.z = 1f;

        isEscapeActive = true;

    }

    void Update()
    {

        if(life.rateCounter == 3)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !life.isRatingShown)
            {
                life.isRatingShown = true;
                OpenRatingPanel();
                life.rateCounter = 0;
                GM.SaveGameMenu();
            }            
        }
        else
        {
            if(isEscapeActive && GM.isEscapeActiveGM && !life.isGameOverPanelActive)
            {
                if (Input.GetKeyDown(KeyCode.Escape) && !isExitpanelActive)
                {
                    ExitPanelHolder.SetActive(true);
                    StartCoroutine("OpeningPanel");
                }
                if (Input.GetKeyDown(KeyCode.Escape) && isExitpanelActive)
                {
                    Staying();
                }
            }            
        }
    }

    IEnumerator OpeningPanel()
    {
        sound.PlayotherButton();
        LeanTween.moveLocalY(exitPanel, -73, 0.25f);
        yield return new WaitForSeconds(0.25f);
        isExitpanelActive = true;
    }
    public void ConfirmExit()
    {
        if(!life.isRatingShown)
        {
            life.rateCounter += 1;
        }
        GM.SaveGameMenu();
        Application.Quit();
    }
    public void Staying()
    {
        sound.PlayotherButton();
        StartCoroutine("CloseExitPanel");
    }
    IEnumerator CloseExitPanel()
    {
        LeanTween.moveLocalY(exitPanel, -830, 0.25f);
        yield return new WaitForSeconds(0.25f);
        ExitPanelHolder.SetActive(false);
        isExitpanelActive = false;
    }


    public void OpenRatingPanel()
    {
        sound.PlayotherButton();
        isEscapeActive = false;
        RatingPanel.SetActive(true);
        StartCoroutine("OpenRating");
    }
    IEnumerator OpenRating()
    {
        LeanTween.scale(RatingPHolder, presize, 0.35f);
        yield return new WaitForSeconds(0.35f);
        LeanTween.scale(RatingPHolder, finalsize, 0.15f);
    }


    public void CloseRatingPanel()
    {
        sound.PlayotherButton();
        rateshowCounter = 0;
        StartCoroutine("CloseRating");
    }
    IEnumerator CloseRating()
    {
        LeanTween.scale(RatingPHolder, presize, 0.15f);
        yield return new WaitForSeconds(0.15f);
        LeanTween.scale(RatingPHolder, Vector3.zero, 0.35f);
        yield return new WaitForSeconds(0.35f);
        RatingPanel.SetActive(false);
        isEscapeActive = true;
    }


    public void RateMe()
    {
        sound.PlayotherButton();
        Application.OpenURL(ShareURL);
        CloseRatingPanel();
    }


    public void ClickShareButton()
    {
        sound.PlayotherButton();
        StartCoroutine(TakeSSAndShare());
    }
    private IEnumerator TakeSSAndShare()
    {
        yield return new WaitForEndOfFrame();
        new NativeShare().SetSubject("Popmaze").SetText(ShareURL).Share();


        //Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        //ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        //ss.Apply();

        //string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        //File.WriteAllBytes(filePath, ss.EncodeToPNG());

        //// To avoid memory leaks
        //Destroy(ss);

        //if (NativeShare.TargetExists("com.facebook"))
        //{
        //    new NativeShare().SetSubject("Popmaze").SetText(ShareURL).SetTarget("com.facebook").Share();
        //}


        // Share on WhatsApp only, if installed (Android only)
        //if( NativeShare.TargetExists( "com.whatsapp" ) )
        //	new NativeShare().AddFile( filePath ).SetText( "Hello world!" ).SetTarget( "com.whatsapp" ).Share();
    }



    public void OpenAboutUsPanel()
    {
        sound.PlayotherButton();
        isEscapeActive = false;
        AboutUsPanel.SetActive(true);
        StartCoroutine("OpenAbout");
    }
    IEnumerator OpenAbout()
    {
        LeanTween.scale(AboutHolder, presize, 0.35f);
        yield return new WaitForSeconds(0.35f);
        LeanTween.scale(AboutHolder, finalsize, 0.15f);
    }

    public void CloseAboutUsPanel()
    {
        sound.PlayotherButton();
        StartCoroutine("CloseAboutUs");
    }
    IEnumerator CloseAboutUs()
    {
        LeanTween.scale(AboutHolder, presize, 0.15f);
        yield return new WaitForSeconds(0.15f);
        LeanTween.scale(AboutHolder, Vector3.zero, 0.35f);
        yield return new WaitForSeconds(0.35f);
        AboutUsPanel.SetActive(false);
        isEscapeActive = true;
    }


    public void OpenFacebookbPage()
    {
        sound.PlayotherButton();
        Application.OpenURL("https://www.facebook.com/TechniPhics-108615474081141");
    }

    public void OpenBuyingPanel()
    {
        sound.PlayotherButton();
        isEscapeActive = false;
        BuyingPanel.SetActive(true);
        StartCoroutine("OpenBuying");        
    }
    IEnumerator OpenBuying()
    {
        LeanTween.scale(BpanelHolder, buyingPreSize, 0.35f);
        yield return new WaitForSeconds(0.35f);
        LeanTween.scale(BpanelHolder, buyingFinalSize, 0.15f);
    }

    public void CloseBuyingPanel()
    {
        sound.PlayotherButton();
        StartCoroutine("CloseBuying");
    }
    IEnumerator CloseBuying()
    {
        LeanTween.scale(BpanelHolder, buyingPreSize, 0.15f);
        yield return new WaitForSeconds(0.15f);
        LeanTween.scale(BpanelHolder, Vector3.zero, 0.35f);
        yield return new WaitForSeconds(0.35f);
        BuyingPanel.SetActive(false);
        isEscapeActive = true;
    }


}
