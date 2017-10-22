using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValues : MonoBehaviour
{

    public static Text MoneyText;
    public static int Playermoney;
    public static Player Player = new Player();
    
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        SetMoneyStart();
    }

    private static void SetMoneyStart()
    {
        if (MoneyText)
        {
            MoneyText.text = "MONEY: " + Playermoney;
        }
    }

    public static void SetLevel(int level)
    {
        Player.level = level;
        print(Player.level);
    }

}

public class Player
{
    public int level;

    public int money;
}
