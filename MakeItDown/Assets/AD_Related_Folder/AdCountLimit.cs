using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdCountLimit : MonoBehaviour
{
    public StarLife life;
    public LevelsAdmanager LAD;
    public AllSoundFx sound;

    public int LevelNumber;
    public GameObject OutofAd;

    public void ClickDoubleDiamondVideo()
    {
        sound.PlayotherButton();
        if(LevelNumber == 1)
        {
            if(life.AdlimitCounter[0] >= 1)
            {
                ShowOutofAd();
            }
            else if(life.AdlimitCounter[0] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        else if (LevelNumber == 2)
        {
            if (life.AdlimitCounter[1] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[1] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 4)
        {
            if (life.AdlimitCounter[3] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[3] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        else if (LevelNumber == 5)
        {
            if (life.AdlimitCounter[4] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[4] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 7)
        {
            if (life.AdlimitCounter[6] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[6] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        else if (LevelNumber == 8)
        {
            if (life.AdlimitCounter[7] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[7] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 10)
        {
            if (life.AdlimitCounter[9] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[9] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 12)
        {
            if (life.AdlimitCounter[11] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[11] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 14)
        {
            if (life.AdlimitCounter[13] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[13] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        else if (LevelNumber == 15)
        {
            if (life.AdlimitCounter[14] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[14] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 17)
        {
            if (life.AdlimitCounter[16] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[16] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 19)
        {
            if (life.AdlimitCounter[18] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[18] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 21)
        {
            if (life.AdlimitCounter[20] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[20] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 23)
        {
            if (life.AdlimitCounter[22] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[22] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 25)
        {
            if (life.AdlimitCounter[24] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[24] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        else if (LevelNumber == 26)
        {
            if (life.AdlimitCounter[25] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[25] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 28)
        {
            if (life.AdlimitCounter[27] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[27] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        else if (LevelNumber == 29)
        {
            if (life.AdlimitCounter[28] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[28] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 31)
        {
            if (life.AdlimitCounter[30] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[30] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 33)
        {
            if (life.AdlimitCounter[32] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[32] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 35)
        {
            if (life.AdlimitCounter[34] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[34] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 37)
        {
            if (life.AdlimitCounter[36] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[36] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        else if (LevelNumber == 38)
        {
            if (life.AdlimitCounter[37] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[37] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 40)
        {
            if (life.AdlimitCounter[39] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[39] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        else if (LevelNumber == 41)
        {
            if (life.AdlimitCounter[40] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[40] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 43)
        {
            if (life.AdlimitCounter[42] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[42] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 45)
        {
            if (life.AdlimitCounter[44] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[44] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        else if (LevelNumber == 46)
        {
            if (life.AdlimitCounter[45] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[45] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 48)
        {
            if (life.AdlimitCounter[47] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[47] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        else if (LevelNumber == 49)
        {
            if (life.AdlimitCounter[48] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[48] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 51)
        {
            if (life.AdlimitCounter[50] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[50] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        else if (LevelNumber == 52)
        {
            if (life.AdlimitCounter[51] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[51] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 54)
        {
            if (life.AdlimitCounter[53] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[53] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 56)
        {
            if (life.AdlimitCounter[55] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[55] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 58)
        {
            if (life.AdlimitCounter[57] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[57] < 1)
            {
                LAD.DisplayVideo_AD_forDoubleDiamond();
            }
        }
        
        else if (LevelNumber == 60)
        {
            if (life.AdlimitCounter[59] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[59] < 1)
            {
                LAD.DisplayVideo_AD_forFinalDouble();
            }
        }
    }

    public void ClickReviveVideo()
    {
        sound.PlayotherButton();
        if (LevelNumber == 1)
        {
            if (life.AdlimitCounter[0] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[0] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 2)
        {
            if (life.AdlimitCounter[1] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[1] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 3)
        {
            if (life.AdlimitCounter[2] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[2] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 4)
        {
            if (life.AdlimitCounter[3] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[3] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 5)
        {
            if (life.AdlimitCounter[4] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[4] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 6)
        {
            if (life.AdlimitCounter[5] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[5] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 7)
        {
            if (life.AdlimitCounter[6] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[6] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 8)
        {
            if (life.AdlimitCounter[7] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[7] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 9)
        {
            if (life.AdlimitCounter[8] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[8] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 10)
        {
            if (life.AdlimitCounter[9] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[9] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 11)
        {
            if (life.AdlimitCounter[10] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[10] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 12)
        {
            if (life.AdlimitCounter[11] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[11] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 13)
        {
            if (life.AdlimitCounter[12] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[12] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 14)
        {
            if (life.AdlimitCounter[13] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[13] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 15)
        {
            if (life.AdlimitCounter[14] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[14] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 16)
        {
            if (life.AdlimitCounter[15] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[15] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 17)
        {
            if (life.AdlimitCounter[16] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[16] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 18)
        {
            if (life.AdlimitCounter[17] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[17] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 19)
        {
            if (life.AdlimitCounter[18] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[18] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 20)
        {
            if (life.AdlimitCounter[19] >= 1)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[19] < 1)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 21)
        {
            if (life.AdlimitCounter[20] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[20] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 22)
        {
            if (life.AdlimitCounter[21] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[21] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 23)
        {
            if (life.AdlimitCounter[22] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[22] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 24)
        {
            if (life.AdlimitCounter[23] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[23] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 25)
        {
            if (life.AdlimitCounter[24] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[24] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 26)
        {
            if (life.AdlimitCounter[25] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[25] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 27)
        {
            if (life.AdlimitCounter[26] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[26] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 28)
        {
            if (life.AdlimitCounter[27] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[27] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 29)
        {
            if (life.AdlimitCounter[28] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[28] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 30)
        {
            if (life.AdlimitCounter[29] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[29] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 31)
        {
            if (life.AdlimitCounter[30] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[30] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 32)
        {
            if (life.AdlimitCounter[31] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[31] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 33)
        {
            if (life.AdlimitCounter[32] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[32] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 34)
        {
            if (life.AdlimitCounter[33] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[33] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 35)
        {
            if (life.AdlimitCounter[34] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[34] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 36)
        {
            if (life.AdlimitCounter[35] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[35] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 37)
        {
            if (life.AdlimitCounter[36] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[36] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 38)
        {
            if (life.AdlimitCounter[37] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[37] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 39)
        {
            if (life.AdlimitCounter[38] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[38] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 40)
        {
            if (life.AdlimitCounter[39] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[39] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 41)
        {
            if (life.AdlimitCounter[40] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[40] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 42)
        {
            if (life.AdlimitCounter[41] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[41] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 43)
        {
            if (life.AdlimitCounter[42] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[42] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 44)
        {
            if (life.AdlimitCounter[43] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[43] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 45)
        {
            if (life.AdlimitCounter[44] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[44] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 46)
        {
            if (life.AdlimitCounter[45] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[45] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 47)
        {
            if (life.AdlimitCounter[46] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[46] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 48)
        {
            if (life.AdlimitCounter[47] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[47] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 49)
        {
            if (life.AdlimitCounter[48] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[48] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 50)
        {
            if (life.AdlimitCounter[49] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[49] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 51)
        {
            if (life.AdlimitCounter[50] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[50] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 52)
        {
            if (life.AdlimitCounter[51] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[51] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 53)
        {
            if (life.AdlimitCounter[52] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[52] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 54)
        {
            if (life.AdlimitCounter[53] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[53] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 55)
        {
            if (life.AdlimitCounter[54] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[54] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 56)
        {
            if (life.AdlimitCounter[55] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[55] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 57)
        {
            if (life.AdlimitCounter[56] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[56] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 58)
        {
            if (life.AdlimitCounter[57] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[57] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 59)
        {
            if (life.AdlimitCounter[58] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[58] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
        else if (LevelNumber == 60)
        {
            if (life.AdlimitCounter[59] >= 2)
            {
                ShowOutofAd();
            }
            else if (life.AdlimitCounter[59] < 2)
            {
                LAD.DisplayVideo_AD_forCont();
            }
        }
    }

    public void ShowOutofAd()
    {
        OutofAd.SetActive(true);
    }
    public void CloseOutofAd()
    {
        sound.PlayotherButton();
        OutofAd.SetActive(false);
    }

    public void IncreaseAdLimitCounter()
    {
        if(LevelNumber == 1)
        {
            life.AdlimitCounter[0]++;
        }
        else if (LevelNumber == 2)
        {
            life.AdlimitCounter[1]++;
        }
        else if (LevelNumber == 3)
        {
            life.AdlimitCounter[2]++;
        }
        else if (LevelNumber == 4)
        {
            life.AdlimitCounter[3]++;
        }
        else if (LevelNumber == 5)
        {
            life.AdlimitCounter[4]++;
        }
        else if (LevelNumber == 6)
        {
            life.AdlimitCounter[5]++;
        }
        else if (LevelNumber == 7)
        {
            life.AdlimitCounter[6]++;
        }
        else if (LevelNumber == 8)
        {
            life.AdlimitCounter[7]++;
        }
        else if (LevelNumber == 9)
        {
            life.AdlimitCounter[8]++;
        }
        else if (LevelNumber == 10)
        {
            life.AdlimitCounter[9]++;
        }
        else if (LevelNumber == 11)
        {
            life.AdlimitCounter[10]++;
        }
        else if (LevelNumber == 12)
        {
            life.AdlimitCounter[11]++;
        }
        else if (LevelNumber == 13)
        {
            life.AdlimitCounter[12]++;
        }
        else if (LevelNumber == 14)
        {
            life.AdlimitCounter[13]++;
        }
        else if (LevelNumber == 15)
        {
            life.AdlimitCounter[14]++;
        }
        else if (LevelNumber == 16)
        {
            life.AdlimitCounter[15]++;
        }
        else if (LevelNumber == 17)
        {
            life.AdlimitCounter[16]++;
        }
        else if (LevelNumber == 18)
        {
            life.AdlimitCounter[17]++;
        }
        else if (LevelNumber == 19)
        {
            life.AdlimitCounter[18]++;
        }
        else if (LevelNumber == 20)
        {
            life.AdlimitCounter[19]++;
        }
        else if (LevelNumber == 21)
        {
            life.AdlimitCounter[20]++;
        }
        else if (LevelNumber == 22)
        {
            life.AdlimitCounter[21]++;
        }
        else if (LevelNumber == 23)
        {
            life.AdlimitCounter[22]++;
        }
        else if (LevelNumber == 24)
        {
            life.AdlimitCounter[23]++;
        }
        else if (LevelNumber == 25)
        {
            life.AdlimitCounter[24]++;
        }
        else if (LevelNumber == 26)
        {
            life.AdlimitCounter[25]++;
        }
        else if (LevelNumber == 27)
        {
            life.AdlimitCounter[26]++;
        }
        else if (LevelNumber == 28)
        {
            life.AdlimitCounter[27]++;
        }
        else if (LevelNumber == 29)
        {
            life.AdlimitCounter[28]++;
        }
        else if (LevelNumber == 30)
        {
            life.AdlimitCounter[29]++;
        }
        else if (LevelNumber == 31)
        {
            life.AdlimitCounter[30]++;
        }
        else if (LevelNumber == 32)
        {
            life.AdlimitCounter[31]++;
        }
        else if (LevelNumber == 33)
        {
            life.AdlimitCounter[32]++;
        }
        else if (LevelNumber == 34)
        {
            life.AdlimitCounter[33]++;
        }
        else if (LevelNumber == 35)
        {
            life.AdlimitCounter[34]++;
        }
        else if (LevelNumber == 36)
        {
            life.AdlimitCounter[35]++;
        }
        else if (LevelNumber == 37)
        {
            life.AdlimitCounter[36]++;
        }
        else if (LevelNumber == 38)
        {
            life.AdlimitCounter[37]++;
        }
        else if (LevelNumber == 39)
        {
            life.AdlimitCounter[38]++;
        }
        else if (LevelNumber == 40)
        {
            life.AdlimitCounter[39]++;
        }
        else if (LevelNumber == 41)
        {
            life.AdlimitCounter[40]++;
        }
        else if (LevelNumber == 42)
        {
            life.AdlimitCounter[41]++;
        }
        else if (LevelNumber == 43)
        {
            life.AdlimitCounter[42]++;
        }
        else if (LevelNumber == 44)
        {
            life.AdlimitCounter[43]++;
        }
        else if (LevelNumber == 45)
        {
            life.AdlimitCounter[44]++;
        }
        else if (LevelNumber == 46)
        {
            life.AdlimitCounter[45]++;
        }
        else if (LevelNumber == 47)
        {
            life.AdlimitCounter[46]++;
        }
        else if (LevelNumber == 48)
        {
            life.AdlimitCounter[47]++;
        }
        else if (LevelNumber == 49)
        {
            life.AdlimitCounter[48]++;
        }
        else if (LevelNumber == 50)
        {
            life.AdlimitCounter[49]++;
        }
        else if (LevelNumber == 51)
        {
            life.AdlimitCounter[50]++;
        }
        else if (LevelNumber == 52)
        {
            life.AdlimitCounter[51]++;
        }
        else if (LevelNumber == 53)
        {
            life.AdlimitCounter[52]++;
        }
        else if (LevelNumber == 54)
        {
            life.AdlimitCounter[53]++;
        }
        else if (LevelNumber == 55)
        {
            life.AdlimitCounter[54]++;
        }
        else if (LevelNumber == 56)
        {
            life.AdlimitCounter[55]++;
        }
        else if (LevelNumber == 57)
        {
            life.AdlimitCounter[56]++;
        }
        else if (LevelNumber == 58)
        {
            life.AdlimitCounter[57]++;
        }
        else if (LevelNumber == 59)
        {
            life.AdlimitCounter[58]++;
        }
        else if (LevelNumber == 60)
        {
            life.AdlimitCounter[59]++;
        }
    }
    
}
