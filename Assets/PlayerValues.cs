using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValues : MonoBehaviour
{

    public static int Playermoney;
    public static Player Player = new Player();
   
    public static void SetProgress(int level)
    {
        Player.money = MoneyPickup.GetTotalMoney();
        print(Player.money);
        if (CheckProgress(level))
        {
            Player.level = level;
        }

        SaveSystem.Save();
    }

    public static bool CheckProgress(int levelNumber)
    {
        if (levelNumber > Player.level)
        {
            return true;
        }
        return false;
    }
}

[System.Serializable]
public class Player
{
    public int level = 2;
    public int money = 1000;
    public int Engine = 0;
    public int Wheels = 0;
    public int Drivetrain = 0;
    public float gameVolume = 0.5f;
    public float musicVolume = 0.5f;
    public bool[] UnlockedUpgrades = new bool[9];

}
