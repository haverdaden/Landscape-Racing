using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public GameObject ContinueButton;
    public GameObject NewGamePanel;
    public Toggle UseBloodToggle;
    private bool _useBlood;

    void Start()
    {
        if (SaveSystem.SaveExist())
        {
            //LOAD IN ALL THE PLAYER VALUES ON GAME START
            SaveSystem.Load();
            ContinueButton.SetActive(true);
            UseBloodToggle.isOn = PlayerValues.Player.UseBlood;
        }
    }

    public void StartNewGame()
    {
        SaveSystem.DeleteSave();
        PlayerValues.Player.UseBlood = _useBlood;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ShowNewGameConfirm()
    {       
        if (SaveSystem.SaveExist())
        {
            //Show Confirm Box
            NewGamePanel.SetActive(true);
            return;
        }
        // Else Start New Game
        StartNewGame();
    }

    public void HideNewGameConfirm()
    {
        NewGamePanel.SetActive(false);
    }

    public void SetUseBlood()
    {
        PlayerValues.Player.UseBlood = !PlayerValues.Player.UseBlood;
        _useBlood = PlayerValues.Player.UseBlood;
        SaveSystem.Save();
    }

}
