using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPGScore : MonoBehaviour
{
    public static int score = 0;

    public void IncrementScore()
    {
        score++;

        PlayerPrefs.SetInt("GPGScoretoUpdate", PlayerPrefs.GetInt("GPGScoretoUpdate", 0) + 1);
    }


}
