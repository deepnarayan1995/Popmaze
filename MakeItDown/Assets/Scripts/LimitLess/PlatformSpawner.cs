using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject platform_Normal;
    public GameObject platform_Magnet;
    public GameObject platform_Cutter1;
    public GameObject platform_throwKnives;
    public GameObject Slide_Left;
    public GameObject Slide_Right;
    public GameObject Platform_Cutter2;
    public GameObject platform_MiddleHole;
    
    public float gameplayTimer;

    public float platform_spawn_timer;
    public float secondSpawntimer;
    public float thirdSpawntimer;
    public float fourthSpawntimer;
    public float fifthSpawntimer;
    public float SixthSpawntimer;
    public float SeventhSpawntimer;
    public float EightSpawntimer;
    public float NinthSpawntimer;
    public float TenthSpawntimer;


    private float current_platform_spawn_timer;
    private int platform_spawn_count = 0;

    public float min_x = -1.25f, max_x = 1.25f;
    private float platform_Xpos;

    public LimitlessGameManager GM;


    void Start()
    {
        current_platform_spawn_timer = platform_spawn_timer;
        gameplayTimer = 0f;
    }

    void Update()
    {
        gameplayTimer += Time.deltaTime / 60;

        current_platform_spawn_timer += Time.deltaTime;


        
        if(current_platform_spawn_timer >= platform_spawn_timer)
        {
            if(gameplayTimer <= 0.5f)
            {
                Round1SpawnPlatforms();
            }
            else if (gameplayTimer > 0.5f && gameplayTimer <= 1f)
            {
                platform_spawn_timer = secondSpawntimer;
                GM.isSecondPhaseLL = true;
                Round2SpawnPlatforms();
            }
            else if (gameplayTimer > 1f && gameplayTimer <= 1.6f)
            {
                platform_spawn_timer = thirdSpawntimer;
                GM.isSecondPhaseLL = false;
                GM.isThirdPhaseLL = true;
                Round3SpawnPlatforms();
            }
            else if (gameplayTimer > 1.6f && gameplayTimer <= 2.3f)
            {
                platform_spawn_timer = fourthSpawntimer;
                GM.isThirdPhaseLL = false;
                GM.isFourthPhaseLL = true;
                Round4SpawnPlatforms();
            }
            else if (gameplayTimer > 2.3f && gameplayTimer <= 3.1f)
            {
                platform_spawn_timer = fifthSpawntimer;
                GM.isFourthPhaseLL = false;
                GM.isFifthPhaseLL = true;
                Round5SpawnPlatforms();
            }
            else if (gameplayTimer > 3.1f && gameplayTimer <= 4f)
            {
                platform_spawn_timer = SixthSpawntimer;
                GM.isFifthPhaseLL = false;
                GM.isSixthPhaseLL = true;
                Round6SpawnPlatforms();
            }
            else if (gameplayTimer > 4f && gameplayTimer <= 5.5f)
            {
                platform_spawn_timer = SeventhSpawntimer;
                GM.isSixthPhaseLL = false;
                GM.isSeventhPhaseLL = true;
                Round7SpawnPlatforms();
            }
            else if (gameplayTimer > 5.5f && gameplayTimer <= 7.5f)
            {
                platform_spawn_timer = EightSpawntimer;
                GM.isSeventhPhaseLL = false;
                GM.isEightPhaseLL = true;
                if(Random.Range(0,2) > 0)
                {
                    Round6SpawnPlatforms();
                }
                else
                {
                    Round7SpawnPlatforms();
                }
            }
            else if (gameplayTimer > 7.5f && gameplayTimer <= 10f)
            {
                platform_spawn_timer = NinthSpawntimer;
                GM.isEightPhaseLL = false;
                GM.isNinthPhaseLL = true;
                if (Random.Range(0, 2) > 0)
                {
                    Round6SpawnPlatforms();
                }
                else
                {
                    Round7SpawnPlatforms();
                }
            }
            else if (gameplayTimer > 10f)
            {
                platform_spawn_timer = TenthSpawntimer;
                GM.isNinthPhaseLL = false;
                GM.isTenthPhaseLL = true;
                if (Random.Range(0, 2) > 0)
                {
                    Round6SpawnPlatforms();
                }
                else
                {
                    Round7SpawnPlatforms();
                }
            }
        }
        //Debug.Log("Gameplaytimer: " + gameplayTimer);
    }

    void Round1SpawnPlatforms()
    {
        Vector3 temp = transform.position;
        if (platform_Xpos == 0)
        {
            temp.x = Random.Range(min_x, max_x);
        }
        else if (platform_Xpos > 0)
        {
            temp.x = Random.Range(min_x, 0);
        }
        else if (platform_Xpos < 0)
        {
            temp.x = Random.Range(0, max_x);
        }

        if(temp.x <= -0.9f && temp.x >= -0.99f)
        {
            temp.x = -1f;
        }
        else if(temp.x >= 0.9f && temp.x <= 0.99f)
        {
            temp.x = 1f;
        }

        GameObject newPlatform = null;

        if (platform_spawn_count < 2)
        {
            newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count >= 2 && platform_spawn_count < 4)
        {
            newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 4)
        {
            newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            platform_spawn_count = 0;
            platform_Xpos = temp.x;
        }

        current_platform_spawn_timer = 0f;


    }

    void Round2SpawnPlatforms()
    {
        Vector3 temp = transform.position;
        if (platform_Xpos == 0)
        {
            temp.x = Random.Range(min_x, max_x);
        }
        else if (platform_Xpos > 0)
        {
            temp.x = Random.Range(min_x, 0);
        }
        else if (platform_Xpos < 0)
        {
            temp.x = Random.Range(0, max_x);
        }

        GameObject newPlatform = null;

        if (platform_spawn_count < 1)
        {
            newPlatform = Instantiate(platform_Cutter1, temp, Quaternion.identity);
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count >= 1 && platform_spawn_count < 3)
        {
            if(Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 3)
        {
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_Cutter1, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if(platform_spawn_count == 4)
        {
            newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            platform_spawn_count = 0;
            platform_Xpos = temp.x;
        }


        current_platform_spawn_timer = 0f;
    }

    void Round3SpawnPlatforms()
    {
        Vector3 temp = transform.position;
        if (platform_Xpos == 0)
        {
            temp.x = Random.Range(min_x, max_x);
        }
        else if (platform_Xpos > 0)
        {
            temp.x = Random.Range(min_x, 0);
        }
        else if (platform_Xpos < 0)
        {
            temp.x = Random.Range(0, max_x);
        }

        GameObject newPlatform = null;

        if (platform_spawn_count < 2)
        {
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 2)
        {
            temp.x = 0;
            newPlatform = Instantiate(platform_throwKnives, temp, Quaternion.identity);
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count >= 3 && platform_spawn_count < 5)
        {
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 5)
        {
            newPlatform = Instantiate(platform_Cutter1, temp, Quaternion.identity);
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 6)
        {
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 7)
        {
            newPlatform = Instantiate(platform_Cutter1, temp, Quaternion.identity);
            platform_spawn_count = 0;
            platform_Xpos = temp.x;
        }


        current_platform_spawn_timer = 0f;
    }

    void Round4SpawnPlatforms()
    {
        Vector3 temp = transform.position;
        if (platform_Xpos == 0)
        {
            temp.x = Random.Range(min_x, max_x);
        }
        else if (platform_Xpos > 0)
        {
            temp.x = Random.Range(min_x, 0);
        }
        else if (platform_Xpos < 0)
        {
            temp.x = Random.Range(0, max_x);
        }

        GameObject newPlatform = null;

        if (platform_spawn_count < 2)
        {
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 2)
        {
            temp.x = 0;
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(Slide_Left, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(Slide_Right, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count >= 3 && platform_spawn_count < 5)
        {
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 5)
        {
            if (Random.Range(0, 2) > 0)
            {
                temp.x = min_x;
            }
            else
            {
                temp.x = max_x;
            }
            newPlatform = Instantiate(platform_Cutter1, temp, Quaternion.identity);
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 6)
        {
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 7)
        {
            if (Random.Range(0, 2) > 0)
            {
                temp.x = min_x;
            }
            else
            {
                temp.x = max_x;
            }
            newPlatform = Instantiate(platform_Cutter1, temp, Quaternion.identity);
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 8)
        {
            temp.x = 0;
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(Slide_Left, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(Slide_Right, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 9)
        {
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 10)
        {
            temp.x = 0;
            newPlatform = Instantiate(platform_throwKnives, temp, Quaternion.identity);
            platform_spawn_count = 0;
            platform_Xpos = temp.x;
        }


        current_platform_spawn_timer = 0f;
    }

    void Round5SpawnPlatforms()
    {
        Vector3 temp = transform.position;
        if (platform_Xpos == 0)
        {
            temp.x = Random.Range(min_x, max_x);
        }
        else if (platform_Xpos > 0)
        {
            temp.x = Random.Range(min_x, 0);
        }
        else if (platform_Xpos < 0)
        {
            temp.x = Random.Range(0, max_x);
        }

        GameObject newPlatform = null;

        if (platform_spawn_count < 2)
        {
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 2)
        {
            temp.x = 0;
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(Slide_Left, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(Slide_Right, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 3)
        {
            if (Random.Range(0, 2) > 0)
            {
                temp.x = min_x;
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                temp.x = max_x;
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 4)
        {
            temp.x = 0;
            newPlatform = Instantiate(Platform_Cutter2, temp, Quaternion.identity);
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 5)
        {
            if (Random.Range(0, 2) > 0)
            {
                temp.x = max_x;
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                temp.x = min_x;
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 6)
        {
            temp.x = 0;
            newPlatform = Instantiate(platform_Cutter1, temp, Quaternion.identity);
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 7)
        {
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 8)
        {
            temp.x = 0;
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(Slide_Left, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(Slide_Right, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 9)
        {
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 10)
        {
            temp.x = 0;
            newPlatform = Instantiate(platform_throwKnives, temp, Quaternion.identity);
            platform_spawn_count = 0;
            platform_Xpos = temp.x;
        }


        current_platform_spawn_timer = 0f;
    }

    void Round6SpawnPlatforms()
    {
        Vector3 temp = transform.position;
        if (platform_Xpos == 0)
        {
            temp.x = Random.Range(min_x, max_x);
        }
        else if (platform_Xpos > 0)
        {
            temp.x = Random.Range(min_x, 0);
        }
        else if (platform_Xpos < 0)
        {
            temp.x = Random.Range(0, max_x);
        }

        GameObject newPlatform = null;

        if (platform_spawn_count < 2)
        {
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);

            }
            else
            {
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 2)
        {
            temp.x = 0;
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(Slide_Left, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(Slide_Right, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 3)
        {
            if (Random.Range(0, 2) > 0)
            {
                temp.x = min_x;
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                temp.x = max_x;
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 4)
        {
            temp.x = 0;
            newPlatform = Instantiate(platform_MiddleHole, temp, Quaternion.identity);
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 5)
        {
            if (Random.Range(0, 2) > 0)
            {
                temp.x = max_x;
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                temp.x = min_x;
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 6)
        {
            temp.x = 0;
            newPlatform = Instantiate(platform_Cutter1, temp, Quaternion.identity);
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 7)
        {
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 8)
        {
            temp.x = 0;
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(Slide_Left, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(Slide_Right, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 9)
        {
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 10)
        {
            temp.x = 0;
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_throwKnives, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_MiddleHole, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 11)
        {
            if (Random.Range(0, 2) > 0)
            {
                temp.x = 1f;
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                temp.x = -1f;
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 12)
        {
            temp.x = 0;
            newPlatform = Instantiate(Platform_Cutter2, temp, Quaternion.identity);
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 13)
        {
            if (Random.Range(0, 2) > 0)
            {
                temp.x = max_x;
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                temp.x = min_x;
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 14)
        {
            temp.x = 0;
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_throwKnives, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_MiddleHole, temp, Quaternion.identity);
            }
            platform_spawn_count = 0;
            platform_Xpos = temp.x;
        }
        current_platform_spawn_timer = 0f;
    }

    void Round7SpawnPlatforms()
    {
        Vector3 temp = transform.position;
        if (platform_Xpos == 0)
        {
            temp.x = Random.Range(min_x, max_x);
        }
        else if (platform_Xpos > 0)
        {
            temp.x = Random.Range(min_x, 0);
        }
        else if (platform_Xpos < 0)
        {
            temp.x = Random.Range(0, max_x);
        }

        GameObject newPlatform = null;

        if (platform_spawn_count < 2)
        {
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);

            }
            else
            {
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 2)
        {
            temp.x = 0;
            newPlatform = Instantiate(platform_MiddleHole, temp, Quaternion.identity);
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 3)
        {
            if (Random.Range(0, 2) > 0)
            {
                temp.x = min_x;
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                temp.x = max_x;
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 4)
        {
            temp.x = 0;
            newPlatform = Instantiate(platform_Cutter1, temp, Quaternion.identity);            
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 5)
        {
            if (Random.Range(0, 2) > 0)
            {
                temp.x = max_x;
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                temp.x = min_x;
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 6)
        {
            temp.x = 0;
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_throwKnives, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_MiddleHole, temp, Quaternion.identity);
            }
            
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 7)
        {
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 8)
        {
            temp.x = 0;
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(Slide_Left, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(Slide_Right, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 9)
        {
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 10)
        {
            temp.x = 0;
            newPlatform = Instantiate(Platform_Cutter2, temp, Quaternion.identity);            
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 11)
        {
            if (Random.Range(0, 2) > 0)
            {
                temp.x = 1f;
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                temp.x = -1f;
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 12)
        {
            temp.x = 0;
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(Slide_Left, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(Slide_Right, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 13)
        {
            if (Random.Range(0, 2) > 0)
            {
                temp.x = max_x;
                newPlatform = Instantiate(platform_Normal, temp, Quaternion.identity);
            }
            else
            {
                temp.x = min_x;
                newPlatform = Instantiate(platform_Magnet, temp, Quaternion.identity);
            }
            platform_spawn_count++;
            platform_Xpos = temp.x;
        }
        else if (platform_spawn_count == 14)
        {
            temp.x = 0;
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platform_throwKnives, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(platform_MiddleHole, temp, Quaternion.identity);
            }
            platform_spawn_count = 0;
            platform_Xpos = temp.x;
        }
        current_platform_spawn_timer = 0f;
    }



}
