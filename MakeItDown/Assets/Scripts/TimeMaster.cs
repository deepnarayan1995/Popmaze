using UnityEngine;
using System;

public class TimeMaster : MonoBehaviour
{

    DateTime currentDate;
    DateTime oldDate;

    [HideInInspector]
    public string saveLocation;
    public static TimeMaster instance;


    void Awake()
    {
        instance = this;
        saveLocation = "lastSavedDate";
        Debug.Log(DateTime.Now);
    }


    public float CheckDate()
    {
        //save the current time when it starts
        currentDate = DateTime.Now;
        string tempstring = PlayerPrefs.GetString(saveLocation, "1");

        //grab the old time from player prefs
        long tempLong = Convert.ToInt64(tempstring);

        //convert the old time form binary to date time variable
        oldDate = DateTime.FromBinary(tempLong);

        // use the substract method and store the result as a time span
        TimeSpan tDifference = currentDate.Subtract(oldDate);

        return (float)tDifference.TotalSeconds;

    }


    public void SaveDate()
    {
        PlayerPrefs.SetString(saveLocation, System.DateTime.Now.ToBinary().ToString());
    }

    void OnApplicationQuit()
    {
        SaveDate();
    }


}
