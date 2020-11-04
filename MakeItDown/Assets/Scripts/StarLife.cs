using System.Collections;
using UnityEngine;
using TMPro;

public class StarLife : MonoBehaviour
{

    //Remove Ads
    [HideInInspector]
    public int isAdRemoved = 0;
    //Limiltess Unlocking variables
    [HideInInspector]
    public int isLimitlessUnlocked = 0;
    //Total available Diamonds
    [HideInInspector]
    public int diamonds = 100;
    //HighScore in limitless
    [HideInInspector]
    public int HighScore;
    //total locked classic levels
    [HideInInspector]
    public int totalClassicLocked = 59;


    [HideInInspector]
    public int[] AdlimitCounter = new int[60];
    



    [HideInInspector]
    public GameStats mystats;

    [HideInInspector]
    public bool ispathExists;
    [HideInInspector]
    public bool isGameActive = false;
    [HideInInspector]
    public bool isLimitlessActive = false;
    [HideInInspector]
    public int adCounter = 0;

    public bool isInLimitlesslevel;

    //public GameObject OutOfLife;
    public GameObject Gover;
    public GameObject notEnoughCoin;

    //public TextMeshProUGUI starAmount;
    [HideInInspector]
    //public int totalLife;   

    //public int maxlife = 5;

    public GameManager GM;

    //public TextMeshProUGUI timetextSecond;
    public TextMeshProUGUI diamondText;

    //public float totalTimer = 0f;

    //[HideInInspector]
    //public float FirstTimer;
    //[HideInInspector]
    //public float SecondTimer;
    //[HideInInspector]
    //public float timer;    

    //[HideInInspector]
    //public float timerseconds;
    //[HideInInspector]
    //public float timerMinutes;

    //[HideInInspector]
    //public bool isTimerStop = true;
    //[HideInInspector]
    //public bool isOutofLifePanelActive = false;
    //[HideInInspector]
    public bool isGameOverPanelActive = false;
    //bool revivewithdiamond = false;


    //[HideInInspector]
    //public bool isNormalTimerStop = true;

    //[HideInInspector]
    //public int howmanyTimesTimerGoes;

    //for limitless level
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI HighScoreText;
    [HideInInspector]
    public bool isScoring;
    float currentScore;
    [HideInInspector]
    public int cScore;    
    [HideInInspector]
    public int collectedDiamond;

    //for rating panel show
    [HideInInspector]
    public bool isRatingShown;
    [HideInInspector]
    public int rateCounter;    

    //permanently disabling start intro
    [HideInInspector]
    public bool isStartIntroDisabled;

    //[HideInInspector]
    //public float spentTime;

    //[HideInInspector]
    //public float timerLeftAt;
    //[HideInInspector]
    //public bool isExittoOpen;
    //[HideInInspector]
    //public bool isRestartToopen;    

    //[HideInInspector]
    //public bool isLifeIncreased = false;


    void Awake()
    {
        cScore = 0;
        collectedDiamond = 0;
    }

    void Start()
    {
        //spentTime = TimeMaster.instance.CheckDate();

        //if (isExittoOpen)
        //{
        //    //setting life and timer when entering the game.
        //    spentTime = TimeMaster.instance.CheckDate();

        //    if (totalLife >= maxlife)
        //    {
        //        totalLife = maxlife;
        //    }

        //    else if (totalLife == 0)
        //    {
        //        if (spentTime > timerLeftAt)
        //        {
        //            spentTime -= timerLeftAt;
        //            if (spentTime < 121)
        //            {
        //                totalLife += 1;
        //                timer = 121;
        //                timer -= spentTime;
        //                isTimerStop = false;
        //            }
        //            else if (spentTime >= 121 && spentTime < 241)
        //            {
        //                totalLife += 2;
        //                spentTime -= 120;
        //                timer = 121;
        //                timer -= spentTime;
        //                isTimerStop = false;
        //            }
        //            else if (spentTime >= 241 && spentTime < 361)
        //            {
        //                totalLife += 3;
        //                spentTime -= 240;
        //                timer = 121;
        //                timer -= spentTime;
        //                isTimerStop = false;
        //            }
        //            else if (spentTime >= 361 && spentTime < 481)
        //            {
        //                totalLife += 4;
        //                spentTime -= 360;
        //                timer = 121;
        //                timer -= spentTime;
        //                isTimerStop = false;
        //            }
        //            else if (spentTime >= 481)
        //            {
        //                totalLife += 5;
        //                spentTime = 0;
        //                isTimerStop = true;
        //            }
        //        }
        //        else if (spentTime < timerLeftAt)
        //        {
        //            timer = timerLeftAt;
        //            timer -= spentTime;
        //            isTimerStop = false;
        //        }
        //        StartCoroutine("SaveGameAtlifeIncrease");
        //    }

        //    else if (totalLife == 1)
        //    {
        //        if (spentTime > timerLeftAt)
        //        {
        //            spentTime -= timerLeftAt;
        //            if (spentTime < 121)
        //            {
        //                totalLife += 1;
        //                timer = 121;
        //                timer -= spentTime;
        //                isTimerStop = false;
        //            }
        //            else if (spentTime >= 121 && spentTime < 241)
        //            {
        //                totalLife += 2;
        //                spentTime -= 120;
        //                timer = 121;
        //                timer -= spentTime;
        //                isTimerStop = false;
        //            }
        //            else if (spentTime >= 241 && spentTime < 361)
        //            {
        //                totalLife += 3;
        //                spentTime -= 240;
        //                timer = 121;
        //                timer -= spentTime;
        //                isTimerStop = false;
        //            }
        //            else if (spentTime >= 361)
        //            {
        //                totalLife += 4;
        //                spentTime = 0;
        //                isTimerStop = true;
        //            }
        //        }
        //        else if (spentTime < timerLeftAt)
        //        {
        //            timer = timerLeftAt;
        //            timer -= spentTime;
        //            isTimerStop = false;
        //        }
        //        StartCoroutine("SaveGameAtlifeIncrease");
        //    }

        //    else if (totalLife == 2)
        //    {
        //        if (spentTime > timerLeftAt)
        //        {
        //            spentTime -= timerLeftAt;
        //            if (spentTime < 121)
        //            {
        //                totalLife += 1;
        //                timer = 121;
        //                timer -= spentTime;
        //                isTimerStop = false;
        //            }
        //            else if (spentTime >= 121 && spentTime < 241)
        //            {
        //                totalLife += 2;
        //                spentTime -= 120;
        //                timer = 121;
        //                timer -= spentTime;
        //                isTimerStop = false;
        //            }
        //            else if (spentTime >= 241)
        //            {
        //                totalLife += 3;
        //                spentTime = 0;
        //                isTimerStop = true;
        //            }
        //        }
        //        else if (spentTime < timerLeftAt)
        //        {
        //            timer = timerLeftAt;
        //            timer -= spentTime;
        //            isTimerStop = false;
        //        }
        //        StartCoroutine("SaveGameAtlifeIncrease");
        //    }

        //    else if (totalLife == 3)
        //    {
        //        if (spentTime > timerLeftAt)
        //        {
        //            spentTime -= timerLeftAt;
        //            if (spentTime < 121)
        //            {
        //                totalLife += 1;
        //                timer = 121;
        //                timer -= spentTime;
        //                isTimerStop = false;
        //            }
        //            else if (spentTime >= 121)
        //            {
        //                totalLife += 2;
        //                spentTime = 0;
        //                isTimerStop = true;
        //            }
        //        }
        //        else if (spentTime < timerLeftAt)
        //        {
        //            timer = timerLeftAt;
        //            timer -= spentTime;
        //            isTimerStop = false;
        //        }
        //        StartCoroutine("SaveGameAtlifeIncrease");
        //    }

        //    else if (totalLife == 4)
        //    {
        //        if (spentTime > timerLeftAt)
        //        {
        //            totalLife += 1;
        //            spentTime = 0;
        //            isTimerStop = true;
        //        }
        //        else if (spentTime < timerLeftAt)
        //        {
        //            timer = timerLeftAt;
        //            timer -= spentTime;
        //            isTimerStop = false;
        //        }
        //        StartCoroutine("SaveGameAtlifeIncrease");
        //    }
        //}
        //else if (!isExittoOpen)
        //{
        //    if(isRestartToopen)
        //    {            
        //        timer = timerLeftAt;
        //        timer -= TimeMaster.instance.CheckDate();
        //    }
        //    else
        //    {
        //        timer = 121;
        //        timer -= TimeMaster.instance.CheckDate();
        //    }            
        //}

        //revivewithdiamond = false;
        //timerLeftAt = 0;
        //isExittoOpen = false;
        //isRestartToopen = false;
        
        if (isInLimitlesslevel)
        {
            HighScoreText.text = "0" + HighScore.ToString();
            currentScore = 0f;
            isScoring = false;
            collectedDiamond = 0;
        }
    }
    
    void Update()
    {

        //for limitless level
        if (isInLimitlesslevel)
        {
            if (diamonds < 9999)
            {
                diamondText.text = diamonds.ToString();
            }
            if (diamonds >= 9999)
            {
                diamondText.text = "9999";
            }

            if (isScoring)
            {
                currentScore += Time.deltaTime;
                cScore = (int)currentScore;
                currentScoreText.text = "0" + cScore.ToString();

            }
            
            return;
        }
        //upto this

        if (diamonds <= 0)
        {
            diamonds = 0;
        }
        if (diamonds < 9999)
        {
            diamondText.text = diamonds.ToString();
        }
        if(diamonds >= 9999)
        {
            diamondText.text = "9999";
        }
    }

    public void CloseNotenoughCoin()
    {
        GM.sound.PlayotherButton();
        notEnoughCoin.SetActive(false);        
    }

}
