using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorkShop : MonoBehaviour
{

    public Canvas UpgradeUi;

    [Header("Engine Toggles")]
    public List<Toggle> EngineList = new List<Toggle>(5);

    [Header("Wheels Toggles")]
    public List<Toggle> WheelsList = new List<Toggle>(5);

    [Header("Drivetrain Toggles")]
    public List<Toggle> DrivetrainList = new List<Toggle>(2);


    private void Start()
    {
        SetStartUpgrades(EngineList, PlayerValues.Player.Engine);
        SetStartUpgrades(WheelsList, PlayerValues.Player.Wheels);
        SetStartUpgrades(DrivetrainList, PlayerValues.Player.Drivetrain);
    }

    private void SetStartUpgrades(List<Toggle> upgradeList, int upgrade)
    {
        upgradeList[upgrade].isOn = true;
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerValues.Player.level);
    }

    public void ToggleUpgradeMenu()
    {
        UpgradeUi.enabled = !UpgradeUi.enabled;
    }

    public void SetUpgrade(Toggle toggle)
    {

        if (toggle.isOn)
        {
            if (EngineList.Contains(toggle))
            {
                PlayerValues.Player.Engine = EngineList.IndexOf(toggle);
                print("Engine set to: " + EngineList.IndexOf(toggle));
            }
            else if (WheelsList.Contains(toggle))
            {
                PlayerValues.Player.Engine = WheelsList.IndexOf(toggle);
                print("Wheels set to: " + WheelsList.IndexOf(toggle));
            }
            else if (DrivetrainList.Contains(toggle))
            {
                PlayerValues.Player.Engine = DrivetrainList.IndexOf(toggle);
                print("Drivetrain set to: " + DrivetrainList.IndexOf(toggle));
            }
        }
    }

    public void BuyUpgrade(int buyAmount)
    {
        if (buyAmount <= PlayerValues.Player.money)
        {
            print("Buy successful");
        }
        else
        {
            print("Not enough money");
        }
    }

}
