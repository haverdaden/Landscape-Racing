using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorkShop : MonoBehaviour
{

    public Canvas UpgradeUi;
    public Canvas LevelsUI;
    public Dropdown SelectLevelDropdown;
    public Text NotEnoughMoneyText;

    [Header("Engine Toggles")]
    public List<Toggle> EngineList = new List<Toggle>();

    [Header("Wheels Toggles")]
    public List<Toggle> WheelsList = new List<Toggle>();

    [Header("Drivetrain Toggles")]
    public List<Toggle> DrivetrainList = new List<Toggle>();

    [Header("Buy Buttons")]
    public List<Button> BuyButtons = new List<Button>();


    private void Update()
    {
        //TODO TO BE REMOVED
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerValues.Player.money = PlayerValues.Player.money + 10000;
        }
    }

    private void Start()
    {
        CheckUnlocked();
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
    public void ToggleLevelsMenu()
    {
        LevelsUI.enabled = !LevelsUI.enabled;
    }

    public void SetUpgrade(Toggle toggle)
    {

        if (toggle.isOn)
        {
            if (EngineList.Contains(toggle))
            {
                PlayerValues.Player.Engine = EngineList.IndexOf(toggle);
            }
            else if (WheelsList.Contains(toggle))
            {
                PlayerValues.Player.Wheels = WheelsList.IndexOf(toggle);
            }
            else if (DrivetrainList.Contains(toggle))
            {
                PlayerValues.Player.Drivetrain = DrivetrainList.IndexOf(toggle);
            }

            SaveSystem.Save();

        }
    }

    public void BuyUpgrade(Button button)
    {
        var buyAmount = button.gameObject.GetComponent<BuyButton>().BuyAmount;

        if (buyAmount <= PlayerValues.Player.money)
        {
            PlayerValues.Player.UnlockedUpgrades[BuyButtons.IndexOf(button)] = true;
            button.gameObject.GetComponentInParent<Toggle>().interactable = true;
            PlayerValues.Player.money = PlayerValues.Player.money - buyAmount;
            GameObject.FindWithTag("Money").GetComponent<Text>().text = "MONEY: " + PlayerValues.Player.money;
            Destroy(button.gameObject);
            SaveSystem.Save();
        }
        else
        {
            StartCoroutine(DisplayNotEnoughMoney());
        }
    }

    private IEnumerator DisplayNotEnoughMoney()
    {
        if (!NotEnoughMoneyText.enabled)
        {
            NotEnoughMoneyText.enabled = true;
            yield return new WaitForSeconds(2);
            NotEnoughMoneyText.enabled = false;
        }

    }

    private void CheckUnlocked()
    {
        for (int i = 0; i < PlayerValues.Player.UnlockedUpgrades.Length; i++)
        {
            if (PlayerValues.Player.UnlockedUpgrades[i])
            {
                print("PLACE: " + PlayerValues.Player.UnlockedUpgrades[i]);
                var Button = BuyButtons[i];
                Button.GetComponentInParent<Toggle>().interactable = true;
                Destroy(Button.gameObject);
            }
        } 
    }

    public void LoadSelectedLevel()
    {
        SceneManager.LoadScene(SelectLevelDropdown.value + 2);
    }

    

}
