using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class LimitlessBallCollision : MonoBehaviour
{
    //Showing ad after 5 attempts
    public LimitlessAdManager LAD;


    [SerializeField]
    private int maxhealth = 100;
    [HideInInspector]
    public int currenthealth;

    public event Action<float> OnHealthPctChanged = delegate { };
    public GameObject DamageWarning;
    public GameObject TrapBlast;

    public GameObject RecoverDamage;


    public StarLife Score;
    public LimitlessBallMovement moveBall;
    public AllSoundFx sound;
    public LimitlessGameManager GM;
    public SpecialPower spPower;
    public IncreaseHealth ballhealth;

    public GameObject PSpawner;

    public GameObject DiamondCollision;
    GameObject Dcol;

    public GameObject kaboom;
    public GameObject LeftCollision;
    public GameObject RightCollision;


    GameObject Collis;
    Vector2 LeftPoint, RightPoint;

    public GameObject LeftBorderLight;
    public GameObject RightBorderLight;
    public GameObject UpperBorderLight;
    public GameObject LowerBorderLight;


    float yposExpl, xposExpl;
    GameObject expl;

    public TextMeshProUGUI highScoreNormal, currentScoreNormal, DiamondNormal;
    public TextMeshProUGUI HighScoreHigh, DiamondHigh;

    //void Awake()
    //{
    //    GM.isEscapeActive = true;
    //}
    private void OnEnable()
    {
        currenthealth = maxhealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "StartScoring")//collision with scoring point
        {
            Score.isScoring = true;
            spPower.isScoring = true;
            ballhealth.isScoring = true;
            Destroy(other.gameObject);
        }

        if (other.tag == "enemyKnife")
        {
            sound.playTrapBlast();
            expl = Instantiate(TrapBlast) as GameObject;
            expl.transform.position = other.transform.position;
            StartCoroutine("damageWarning");
            DecreaseHealth(-35);
            Destroy(other.gameObject);
        }

        if (other.tag == "enemyWall")//Collision with spikes and other enemy
        {
            GM.isGameover = true;
            GM.isBallDestroyed = true;

            if (Score.isAdRemoved == 0)
            {
                if (Score.adCounter >= 3)
                {
                    LAD.DisplayVideoGover();
                    Score.adCounter = 0;
                    GM.SaveLimitless();
                }
                else
                {
                    Score.adCounter++;
                }
            }


            UpperBorderLight.SetActive(true);
            spPower.isScoring = false;
            ballhealth.isScoring = false;

            moveBall.isLeft = false;
            moveBall.isRight = false;
            sound.playBlastSound();
            sound.limlessBGMusic.Stop();
            sound.PlayLimLessFallen();

            if (other.transform.position.y > 4.2f)
            {
                xposExpl = this.transform.position.x;
                yposExpl = 4.2f;
            }
            else
            {
                xposExpl = this.transform.position.x;
                yposExpl = other.transform.position.y;
            }
            expl = Instantiate(kaboom) as GameObject;
            expl.transform.position = new Vector3(xposExpl, yposExpl, 0);
            this.gameObject.SetActive(false);

            highScoreNormal.text = HighScoreHigh.text = Score.HighScore.ToString();
            currentScoreNormal.text = Score.cScore.ToString();
            DiamondNormal.text = DiamondHigh.text = Score.collectedDiamond.ToString();

            if (Score.cScore > Score.HighScore)
            {
                Score.isScoring = false;
                PSpawner.SetActive(false);
                Score.HighScore = Score.cScore;
                HighScoreHigh.text = Score.HighScore.ToString();
                GM.StartCoroutine("ShowGoverHigh");
            }
            else
            {
                Score.isScoring = false;
                PSpawner.SetActive(false);
                GM.StartCoroutine("ShowGovernormal");
            }
            GM.SaveLimitless();
        }

        if(other.tag == "GameOverLine")
        {
            GM.isGameover = true;
            GM.isBallDestroyed = true;

            if (Score.isAdRemoved == 0)
            {
                if (Score.adCounter >= 3)
                {
                    LAD.DisplayVideoGover();
                    Score.adCounter = 0;
                    GM.SaveLimitless();
                }
                else
                {
                    Score.adCounter++;
                }
            }

            LowerBorderLight.SetActive(true);
            spPower.isScoring = false;
            ballhealth.isScoring = false;

            moveBall.isLeft = false;
            moveBall.isRight = false;
            this.gameObject.SetActive(false);

            sound.limlessBGMusic.Stop();
            sound.PlayLimLessFallen();

            highScoreNormal.text = HighScoreHigh.text = Score.HighScore.ToString();
            currentScoreNormal.text = Score.cScore.ToString();
            DiamondNormal.text = DiamondHigh.text = Score.collectedDiamond.ToString();

            if (Score.cScore > Score.HighScore)
            {
                Score.isScoring = false;
                PSpawner.SetActive(false);
                Score.HighScore = Score.cScore;
                HighScoreHigh.text = Score.HighScore.ToString();
                GM.StartCoroutine("ShowGoverHigh");
            }
            else
            {
                Score.isScoring = false;
                PSpawner.SetActive(false);
                GM.StartCoroutine("ShowGovernormal");
            }
            GM.SaveLimitless();
        }

        if(other.tag == "Diamond")
        {
            sound.PlayLimLessDiamondCollect();
            Score.collectedDiamond += 1;
            Vector3 pos = other.transform.position;
            Dcol = Instantiate(DiamondCollision) as GameObject;
            Dcol.transform.position = new Vector3(pos.x, pos.y, 5f);
            StartCoroutine("destroyDcol");
            Destroy(other.gameObject);
            GM.SaveLimitless();
        }

    }

    public void DecreaseHealth(int amount)
    {
        currenthealth += amount;
        float currentHealthPct = (float)currenthealth / (float)maxhealth;
        OnHealthPctChanged(currentHealthPct);

        if (currenthealth <= 0)
        {
            GM.isGameover = true;
            GM.isBallDestroyed = true;
            if (Score.isAdRemoved == 0)
            {
                if (Score.adCounter >= 3)
                {
                    LAD.DisplayVideoGover();
                    Score.adCounter = 0;
                    GM.SaveLimitless();
                }
                else
                {
                    Score.adCounter++;
                }
            }
            spPower.isScoring = false;
            ballhealth.isScoring = false;
            moveBall.isLeft = false;
            moveBall.isRight = false;
            this.gameObject.SetActive(false);
            sound.limlessBGMusic.Stop();
            sound.PlayLimLessFallen();
            highScoreNormal.text = HighScoreHigh.text = Score.HighScore.ToString();
            currentScoreNormal.text = Score.cScore.ToString();
            DiamondNormal.text = DiamondHigh.text = Score.collectedDiamond.ToString();
            if (Score.cScore > Score.HighScore)
            {
                Score.isScoring = false;
                PSpawner.SetActive(false);
                Score.HighScore = Score.cScore;
                HighScoreHigh.text = Score.HighScore.ToString();
                GM.StartCoroutine("ShowGoverHigh");
            }
            else
            {
                Score.isScoring = false;
                PSpawner.SetActive(false);
                GM.StartCoroutine("ShowGovernormal");
            }
            GM.SaveLimitless();
        }
        
    }

    public void IncreaseHealthButton()
    {
        if(ballhealth.isButtonActive)
        {
            ShowRecoverDamage();
        }        
    }

    public void ShowRecoverDamage()
    {
        Time.timeScale = 0f;
        RecoverDamage.SetActive(true);
    }

    public void HideRecoverdamage()
    {
        Time.timeScale = 1f;
        RecoverDamage.SetActive(false);
    }

    public void IncreaseHealth()
    {
        HideRecoverdamage();
        Score.diamonds -= 50;
        GM.SaveLimitless();
        int remainingHealth = maxhealth - currenthealth;
        currenthealth += remainingHealth;
        float currentHealthPct = (float)currenthealth / (float)maxhealth;
        OnHealthPctChanged(currentHealthPct);
    }


    IEnumerator damageWarning()
    {
        DamageWarning.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        DamageWarning.SetActive(false);
        Destroy(expl.gameObject);
    }

    IEnumerator destroyDcol()
    {
        yield return new WaitForSeconds(2f);
        Destroy(Dcol.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "LeftBound")
        {
            ContactPoint2D contact = other.contacts[0];
            LeftPoint.x = contact.point.x;
            LeftPoint.y = contact.point.y;
            Collis = Instantiate(LeftCollision) as GameObject;
            Collis.transform.position = new Vector3(LeftPoint.x, LeftPoint.y, 5f);
            sound.playCollisionSound();
            StartCoroutine("PlayLeftCollision");
        }
        if(other.collider.tag == "RightBound")
        {
            ContactPoint2D contact = other.contacts[0];
            LeftPoint.x = contact.point.x;
            LeftPoint.y = contact.point.y;
            Collis = Instantiate(RightCollision) as GameObject;
            Collis.transform.position = new Vector3(LeftPoint.x, LeftPoint.y, 5f);
            sound.playCollisionSound();
            StartCoroutine("PlayRightCollision");
        }
        if(other.collider.tag == "LimitlessPlatforms")
        {
            this.transform.SetParent(other.transform);
            sound.playCollisionSound();
        }
    }


    void OnCollisionExit2D(Collision2D other)
    {
        this.transform.SetParent(null);
    }



    IEnumerator PlayLeftCollision()
    {
        LeftBorderLight.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        LeftBorderLight.SetActive(false);
        yield return new WaitForSeconds(0.9f);
        Destroy(Collis.gameObject);
    }

    IEnumerator PlayRightCollision()
    {
        RightBorderLight.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        RightBorderLight.SetActive(false);
        yield return new WaitForSeconds(0.9f);
        Destroy(Collis.gameObject);
    }

}
