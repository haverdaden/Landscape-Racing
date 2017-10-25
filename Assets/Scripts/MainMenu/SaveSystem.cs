using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{

    //Loading
    public static void Load()
    {
        print("LOADING");
        string path = Application.persistentDataPath + "/Savegame.txt";

        if (!File.Exists(path))
        {
            return;
        }

        var file = File.Open(path, FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();


  
            PlayerValues.Player = (Player) bf.Deserialize(file);
        

        file.Close();

    }

    public static void Save()
    {
        string path = Application.persistentDataPath + "/Savegame.txt";
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }

        var file = File.Open(path, FileMode.Open);

        BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(file, PlayerValues.Player);
            Debug.Log("SAVED: " + PlayerValues.Player);
        
        file.Close();
    }


    public static bool SaveExist()
    {
        string path = Application.persistentDataPath + "/Savegame.txt";

        if (!File.Exists(path))
        {
            return false;
        }
        return true;
    }

    public static void DeleteSave()
    {
        string path = Application.persistentDataPath + "/Savegame.txt";

        File.Delete(path);

        PlayerValues.Player.money = 0;
        PlayerValues.Player.level = 2;

        Debug.Log(path + " deleted");
    }
}
