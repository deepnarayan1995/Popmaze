using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public GameObject gover;
    public Animator gateanim;
    public GameObject kaboom;
    float yposExpl, xposExpl;
    GameObject expl;

    public GameManager GM;
    public BallMovement moveBall;

    public StarLife health;
    public AllSoundFx sound;
    public LevelsAdmanager LAD;

    public GameObject StartIntro;

    //colourful fireworks effect
    public GameObject CompleteBlast;
    GameObject finalblast;

    //Cool blast effect on finding key
    public GameObject KeyBlast;
    GameObject keyFx;

    //for Starting effect
    public ParticleSystem EntryGatefx;

    //for Primary key and gates
    public PrimaryGates primGate;

    //For FinalLevel all Hotlever
    public GameObject[] Hotlevers = new GameObject[30];
    [HideInInspector]
    public int a, b;

    //FinalEnemyBlast
    public GameObject EnemyBlast;
    GameObject enBlast;
    public ParticleSystem doubleTubri;
    
    void Start()
    {
        a = 50;
        b = 50;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "enemy")//Collision with enemy
        {
            moveBall.isLeft = false;
            moveBall.isRight = false;
            sound.playBlastSound();
            
            if(other.transform.position.x < -1.9f)
            {
                xposExpl = -1.9f;
                yposExpl = other.transform.position.y;
            }
            else if(other.transform.position.x > 1.9f)
            {
                xposExpl = 1.9f;
                yposExpl = other.transform.position.y;
            }
            else
            {
                xposExpl = other.transform.position.x;
                yposExpl = other.transform.position.y;
            }
            expl = Instantiate(kaboom) as GameObject;
            expl.transform.position = new Vector3(xposExpl, yposExpl, 0);
            Destroy(other.gameObject);
            this.gameObject.SetActive(false);
            GM.isGameover = true;
            GM.StartCoroutine("ShowGameoverPanel");          
        }

        if (other.tag == "Complete")//Level Complete
        {
            if(other.name == "Level1" && health.totalClassicLocked == 59) //!health.isClassicUnLocked[0])
            {
                health.totalClassicLocked = 58;
            }

            else if (other.name == "Level2" && health.totalClassicLocked == 58) //!health.isClassicUnLocked[1])
            {
                health.totalClassicLocked = 57;
            }

            else if (other.name == "Level3" && health.totalClassicLocked == 57) // !health.isClassicUnLocked[2])
            {
                health.totalClassicLocked = 56;
            }

            else if (other.name == "Level4" && health.totalClassicLocked == 56) // !health.isClassicUnLocked[3])
            {
                health.totalClassicLocked = 55;
            }

            else if (other.name == "Level5" && health.totalClassicLocked == 55) // !health.isClassicUnLocked[4])
            {
                GM.SaveThisGame();
                health.totalClassicLocked = 54;
            }

            else if (other.name == "Level6" && health.totalClassicLocked == 54) // !health.isClassicUnLocked[5])
            {
                health.totalClassicLocked = 53;
            }

            else if (other.name == "Level7" && health.totalClassicLocked == 53) // !health.isClassicUnLocked[6])
            {
                health.totalClassicLocked = 52;
            }

            else if (other.name == "Level8" && health.totalClassicLocked == 52) // !health.isClassicUnLocked[7])
            {
                health.totalClassicLocked = 51;
            }

            else if (other.name == "Level9" && health.totalClassicLocked == 51) // !health.isClassicUnLocked[8])
            {
                health.totalClassicLocked = 50;
            }

            else if (other.name == "Level10" && health.totalClassicLocked == 50) // !health.isClassicUnLocked[9])
            {
                GM.SaveThisGame();
                health.totalClassicLocked = 49;
            }

            else if (other.name == "Level11" && health.totalClassicLocked == 49) // !health.isClassicUnLocked[10])
            {
                health.totalClassicLocked = 48;
            }

            else if (other.name == "Level12" && health.totalClassicLocked == 48) // !health.isClassicUnLocked[11])
            {
                health.totalClassicLocked = 47;
            }

            else if (other.name == "Level13" && health.totalClassicLocked == 47) // !health.isClassicUnLocked[12])
            {
                health.totalClassicLocked = 46;
            }

            else if (other.name == "Level14" && health.totalClassicLocked == 46) // !health.isClassicUnLocked[13])
            {
                health.totalClassicLocked = 45;
            }

            else if (other.name == "Level15" && health.totalClassicLocked == 45) // !health.isClassicUnLocked[14])
            {
                health.totalClassicLocked = 44;
            }

            else if (other.name == "Level16" && health.totalClassicLocked == 44) // !health.isClassicUnLocked[15])
            {
                health.totalClassicLocked = 43;
            }

            else if (other.name == "Level17" && health.totalClassicLocked == 43) // !health.isClassicUnLocked[16])
            {
                health.totalClassicLocked = 42;
            }

            else if (other.name == "Level18" && health.totalClassicLocked == 42) // !health.isClassicUnLocked[17])
            {
                health.totalClassicLocked = 41;
            }

            else if (other.name == "Level19" && health.totalClassicLocked == 41) // !health.isClassicUnLocked[18])
            {
                health.totalClassicLocked = 40;
            }

            else if (other.name == "Level20" && health.totalClassicLocked == 40) // !health.isClassicUnLocked[19])
            {
                GM.SaveThisGame();
                health.totalClassicLocked = 39;

                if(health.isLimitlessUnlocked == 0)
                {                   
                    sound.PlayLevelComplete();
                    Vector3 pos1 = other.transform.position;
                    Destroy(other.gameObject);
                    finalblast = Instantiate(CompleteBlast) as GameObject;
                    finalblast.transform.position = pos1;
                    moveBall.isControlActive = false;

                    health.isLimitlessUnlocked = 1;
                    GM.OpenLimitlessUnlockedPanel();
                    GM.SaveThisGame();
                    return;
                }                
            }

            else if (other.name == "Level21" && health.totalClassicLocked == 39) // !health.isClassicUnLocked[20])
            {
                health.totalClassicLocked = 38;
            }

            else if (other.name == "Level22" && health.totalClassicLocked == 38) // !health.isClassicUnLocked[21])
            {
                health.totalClassicLocked = 37;
            }

            else if (other.name == "Level23" && health.totalClassicLocked == 37) // !health.isClassicUnLocked[22])
            {
                health.totalClassicLocked = 36;
            }

            else if (other.name == "Level24" && health.totalClassicLocked == 36) // !health.isClassicUnLocked[23])
            {
                health.totalClassicLocked = 35;
            }

            else if (other.name == "Level25" && health.totalClassicLocked == 35) // !health.isClassicUnLocked[24])
            {
                health.totalClassicLocked = 34;
            }

            else if (other.name == "Level26" && health.totalClassicLocked == 34) // !health.isClassicUnLocked[25])
            {
                health.totalClassicLocked = 33;
            }

            else if (other.name == "Level27" && health.totalClassicLocked == 33) // !health.isClassicUnLocked[26])
            {
                health.totalClassicLocked = 32;
            }

            else if (other.name == "Level28" && health.totalClassicLocked == 32) // !health.isClassicUnLocked[27])
            {
                health.totalClassicLocked = 31;
            }

            else if (other.name == "Level29" && health.totalClassicLocked == 31) // !health.isClassicUnLocked[28])
            {
                health.totalClassicLocked = 30;
            }

            else if (other.name == "Level30" && health.totalClassicLocked == 30) // !health.isClassicUnLocked[29])
            {
                GM.SaveThisGame();
                health.totalClassicLocked = 29;
            }

            else if (other.name == "Level31" && health.totalClassicLocked == 29) // !health.isClassicUnLocked[30])
            {
                health.totalClassicLocked = 28;
            }

            else if (other.name == "Level32" && health.totalClassicLocked == 28) // !health.isClassicUnLocked[31])
            {
                health.totalClassicLocked = 27;
            }

            else if (other.name == "Level33" && health.totalClassicLocked == 27) // !health.isClassicUnLocked[32])
            {
                health.totalClassicLocked = 26;
            }

            else if (other.name == "Level34" && health.totalClassicLocked == 26) // !health.isClassicUnLocked[33])
            {
                health.totalClassicLocked = 25;
            }

            else if (other.name == "Level35" && health.totalClassicLocked == 25) // !health.isClassicUnLocked[34])
            {
                health.totalClassicLocked = 24;
            }

            else if (other.name == "Level36" && health.totalClassicLocked == 24) // !health.isClassicUnLocked[35])
            {
                health.totalClassicLocked = 23;
            }

            else if (other.name == "Level37" && health.totalClassicLocked == 23) // !health.isClassicUnLocked[36])
            {
                health.totalClassicLocked = 22;
            }

            else if (other.name == "Level38" && health.totalClassicLocked == 22) // !health.isClassicUnLocked[37])
            {
                health.totalClassicLocked = 21;
            }

            else if (other.name == "Level39" && health.totalClassicLocked == 21) // !health.isClassicUnLocked[38])
            {
                health.totalClassicLocked = 20;
            }

            else if (other.name == "Level40" && health.totalClassicLocked == 20) // !health.isClassicUnLocked[39])
            {
                GM.SaveThisGame();
                health.totalClassicLocked = 19;
            }

            else if (other.name == "Level41" && health.totalClassicLocked == 19) // !health.isClassicUnLocked[40])
            {
                health.totalClassicLocked = 18;
            }

            else if (other.name == "Level42" && health.totalClassicLocked == 18) // !health.isClassicUnLocked[41])
            {
                health.totalClassicLocked = 17;
            }

            else if (other.name == "Level43" && health.totalClassicLocked == 17) // !health.isClassicUnLocked[42])
            {
                health.totalClassicLocked = 16;
            }

            else if (other.name == "Level44" && health.totalClassicLocked == 16) // !health.isClassicUnLocked[43])
            {
                health.totalClassicLocked = 15;
            }

            else if (other.name == "Level45" && health.totalClassicLocked == 15) // !health.isClassicUnLocked[44])
            {
                health.totalClassicLocked = 14;
            }

            else if (other.name == "Level46" && health.totalClassicLocked == 14) // !health.isClassicUnLocked[45])
            {
                health.totalClassicLocked = 13;
            }

            else if (other.name == "Level47" && health.totalClassicLocked == 13) // !health.isClassicUnLocked[46])
            {
                health.totalClassicLocked = 12;
            }

            else if (other.name == "Level48" && health.totalClassicLocked == 12) // !health.isClassicUnLocked[47])
            {
                health.totalClassicLocked = 11;
            }

            else if (other.name == "Level49" && health.totalClassicLocked == 11) // !health.isClassicUnLocked[48])
            {
                health.totalClassicLocked = 10;
            }

            else if (other.name == "Level50" && health.totalClassicLocked == 10) // !health.isClassicUnLocked[49])
            {
                GM.SaveThisGame();
                health.totalClassicLocked = 9;
            }

            else if (other.name == "Level51" && health.totalClassicLocked == 9) // !health.isClassicUnLocked[50])
            {
                health.totalClassicLocked = 8;
            }

            else if (other.name == "Level52" && health.totalClassicLocked == 8) // !health.isClassicUnLocked[51])
            {
                health.totalClassicLocked = 7;
            }

            else if (other.name == "Level53" && health.totalClassicLocked == 7) // !health.isClassicUnLocked[52])
            {
                health.totalClassicLocked = 6;
            }

            else if (other.name == "Level54" && health.totalClassicLocked == 6) // !health.isClassicUnLocked[53])
            {
                health.totalClassicLocked = 5;
            }

            else if (other.name == "Level55" && health.totalClassicLocked == 5) // !health.isClassicUnLocked[54])
            {
                health.totalClassicLocked = 4;
            }

            else if (other.name == "Level56" && health.totalClassicLocked == 4) // !health.isClassicUnLocked[55])
            {
                health.totalClassicLocked = 3;
            }

            else if (other.name == "Level57" && health.totalClassicLocked == 3) // !health.isClassicUnLocked[56])
            {
                health.totalClassicLocked = 2;
            }

            else if (other.name == "Level58" && health.totalClassicLocked == 2) // !health.isClassicUnLocked[57])
            {
                health.totalClassicLocked = 1;
            }

            else if (other.name == "Level59" && health.totalClassicLocked == 1)
            {
                health.totalClassicLocked = 0;
            }








            if (health.isAdRemoved == 0)
            {
                if (health.adCounter >= 3)
                {
                    LAD.DisplayVideoOnComplete();
                    health.adCounter = 0;
                    GM.SaveThisGame();
                }
                else
                {
                    health.adCounter++;
                }
            }
            

            sound.PlayLevelComplete();

            Vector3 pos = other.transform.position;
            Destroy(other.gameObject);

            finalblast = Instantiate(CompleteBlast) as GameObject;
            finalblast.transform.position = pos;

            moveBall.isControlActive = false;            
            GM.isLevelComplete = true;
            GM.StartCoroutine("ShowLevelCompletePanel");
            GM.SaveThisGame();
        }

        if(other.tag == "Gate")//Opening Gate and Start Intro
        {
            if(!health.isStartIntroDisabled)
            {
                StartIntro.SetActive(true);
            }
            EntryGatefx.Play();
            sound.CloseEntryGate();
            StartCoroutine("ActiveBallControl");
            gateanim.SetTrigger("CloseGate");
            Destroy(other.gameObject);
        }

        if(other.tag == "Key")//Finding keys
        {
            keyFx = null;
            //StartCoroutine("OpenGate");
            Vector3 pos = other.transform.position;
            keyFx = Instantiate(KeyBlast) as GameObject;
            keyFx.transform.position = new Vector3(pos.x, pos.y, -5f);
            GM.StartCoroutine("OpenFinalGate");
            sound.PlayKeyFound();
            Destroy(other.gameObject);
            
        }

        if (other.name == "key1")
        {
            keyFx = null;
            Vector3 pos = other.transform.position;
            keyFx = Instantiate(KeyBlast) as GameObject;
            keyFx.transform.position = new Vector3(pos.x, pos.y, -5f);
            sound.PlayKeyFound();
            primGate.isKey1Get = true;
            Destroy(other.gameObject);
        }

        if (other.name == "key2")
        {
            keyFx = null;
            Vector3 pos = other.transform.position;
            keyFx = Instantiate(KeyBlast) as GameObject;
            keyFx.transform.position = new Vector3(pos.x, pos.y, -5f);
            sound.PlayKeyFound();
            primGate.isKey2Get = true;
            Destroy(other.gameObject);
        }

        if(other.tag == "FinalLevelEnemy")
        {
            for(int i=0; i < 30; i++)
            {
                if(other.name == Hotlevers[i].name && a == 50)
                {
                    a = i;
                    Debug.Log("Name of A := " + Hotlevers[a].name);
                }
                else if(other.name == Hotlevers[i].name && b == 50)
                {
                    b = i;
                    Debug.Log("Name of B := " + Hotlevers[b].name);
                }
            }

            moveBall.isLeft = false;
            moveBall.isRight = false;
            sound.playBlastSound();

            if (other.transform.position.x < -1.9f)
            {
                xposExpl = -1.9f;
                yposExpl = other.transform.position.y;
            }
            else if (other.transform.position.x > 1.9f)
            {
                xposExpl = 1.9f;
                yposExpl = other.transform.position.y;
            }
            else
            {
                xposExpl = other.transform.position.x;
                yposExpl = other.transform.position.y;
            }
            expl = Instantiate(kaboom) as GameObject;
            expl.transform.position = new Vector3(xposExpl, yposExpl, 0);
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            GM.isGameover = true;
            GM.StartCoroutine("ShowGameoverPanel");
        }

        if(other.tag == "FinalLevelComplete")
        {
            sound.PlayLevelComplete();
            Vector3 pos = other.transform.position;
            Destroy(other.gameObject);
            finalblast = Instantiate(CompleteBlast) as GameObject;
            finalblast.transform.position = pos;
            moveBall.isControlActive = false;
            GM.SaveThisGame();
            sound.PlayfinalBGSound();
            StartCoroutine("OpenFinalPanel");
            StartCoroutine("PlayFinalAnimation");
        }

    }



    IEnumerator ActiveBallControl()
    {
        yield return new WaitForSeconds(0.5f);
        moveBall.isControlActive = true;
        GM.isEscapeActive = true;
    }

       
    IEnumerator OpenFinalPanel()
    {
        yield return new WaitForSeconds(10f);
        GM.isLevelComplete = true;
        GM.StartCoroutine("ShowLevelCompletePanel");
    }

    IEnumerator PlayFinalAnimation()
    {
        yield return new WaitForSeconds(0.2f);
        doubleTubri.Play();
        yield return new WaitForSeconds(3f);

        for(int i=0; i<30; i++)
        {
            if(i != a && i != b)
            {
                Vector3 pos = Hotlevers[i].transform.position;
                sound.PlayFirework();
                enBlast = Instantiate(EnemyBlast) as GameObject;
                enBlast.transform.position = new Vector3(pos.x, pos.y, 0f);

                Hotlevers[i].gameObject.SetActive(false);
                yield return new WaitForSeconds(Random.Range(0.1f, 0.6f));
            }
        }

    }

    public void CloseStartIntro()
    {
        sound.PlayotherButton();
        StartIntro.SetActive(false);
    }

    public void parmanentlyCloseStartInfo()
    {
        sound.PlayotherButton();
        StartIntro.SetActive(false);
        health.isStartIntroDisabled = true;
        GM.SaveThisGame();
    }   

    void OnCollisionEnter2D(Collision2D other)
    {
        sound.playCollisionSound();
        if(other.collider.tag == "OtherWall")
        {
            transform.SetParent(null);
        }
    }

    IEnumerator ShowGameover()
    {
        yield return new WaitForSeconds(0.2f);
        gover.SetActive(true);
    }


}
