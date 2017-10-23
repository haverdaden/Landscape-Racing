﻿using System.Collections;
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

    public int money = 0;
}