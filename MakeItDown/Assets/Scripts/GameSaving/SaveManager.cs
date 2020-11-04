using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{

    public StarLife _starLife;


    public void Save(StarLife life, AllSoundFx sound)
    {
        string gamePath = Application.persistentDataPath + "/Player.dat";

        FileStream fstream = new FileStream(gamePath, FileMode.OpenOrCreate);

        BinaryFormatter formatter = new BinaryFormatter();

        GameStats gStats = new GameStats(life, sound);

        formatter.Serialize(fstream, gStats);

        fstream.Close();

    }

    public void Savefirst()
    {
        string gamePath = Application.persistentDataPath + "/Player.dat";

        FileStream fStream = new FileStream(gamePath, FileMode.Create);
        BinaryFormatter binFor = new BinaryFormatter();
        binFor.Serialize(fStream, _starLife.mystats);
        fStream.Close();
    }

    public void Load()
    {
        string gamePath = Application.persistentDataPath + "/Player.dat";

        if (File.Exists(gamePath))
        {
            _starLife.ispathExists = true;
            FileStream fStream = new FileStream(gamePath, FileMode.Open);

            BinaryFormatter formatter = new BinaryFormatter();

            _starLife.mystats = (GameStats)formatter.Deserialize(fStream) as GameStats;

            fStream.Close();
        }
        else
        {
            _starLife.ispathExists = false;
            Savefirst();
        }
        
        
    }


}
