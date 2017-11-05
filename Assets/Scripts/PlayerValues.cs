using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValues : MonoBehaviour
{
    //Create the player
    public static Player Player = new Player();
}

// Player Object Values
[System.Serializable]
public class Player
{
    public int level = 2;
    public int money = 0;
    public int Engine = 0;
    public int Wheels = 0;
    public int Drivetrain = 0;
    public float gameVolume = 0.5f;
    public float musicVolume = 0.5f;
    public bool[] UnlockedUpgrades = new bool[9];
    public List<int> UnlockedLevels = new List<int>{ 1 };

}
