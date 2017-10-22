using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    public Player Player;

    //Loading
    public static int Load()
    {
        string path = Application.persistentDataPath + "/Savegame.txt";
        if (!File.Exists(path))
        {
            return 0;
        }
        //Read the text from directly from the test.txt file
        var file = File.Open(path, FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();
        int progressLevel = Int32.Parse(bf.Deserialize(file).ToString());
        file.Close();

        return progressLevel;

    }

    public static void Save(int levelNumber)
    {
        string path = Application.persistentDataPath + "/Savegame.txt";
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }

        var file = File.Open(path, FileMode.Open);

        BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(file, levelNumber);
            Debug.Log("SAVED: " + levelNumber);
        
        file.Close();
    }

    public void CheckProgress(int levelNumber)
    {
        if (levelNumber > Load())
        {
            Save(levelNumber);
        }
    }

    public bool SaveExist()
    {
        if (Load() > 0)
        {
            return true;
        }
        return false;
    }//

    public void DeleteSave()
    {
        string path = Application.persistentDataPath + "/Savegame.txt";

        File.Delete(path);

        Debug.Log(path + " deleted");
    }
}
