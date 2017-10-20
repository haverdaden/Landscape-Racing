using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class HighScoreCheck : MonoBehaviour {

    //Highscore Check
    public bool CheckHighScore(float scoreTime)
    {
        if (scoreTime < LoadHighScore())
        {
            SaveHighScore(scoreTime);
            return true;
        }
        return false;

    }

    //Saving
    static void SaveHighScore(float ScoreTime)
    {
        string path = Application.persistentDataPath + "/Highscore" + SceneManager.GetActiveScene().name + ".txt";

        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }

        var file = File.Open(path,FileMode.Open);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file,ScoreTime);
        file.Close();
    }

    //Loading
    static float LoadHighScore()
    {
        string path = Application.persistentDataPath + "/Highscore" + SceneManager.GetActiveScene().name + ".txt";

        if (!File.Exists(path))
        {
            return Single.PositiveInfinity;
        }
        //Read the text from directly from the test.txt file
        var file = File.Open(path, FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();
        float Highscore = float.Parse(bf.Deserialize(file).ToString());
        file.Close();

        return Highscore;

    }
}
