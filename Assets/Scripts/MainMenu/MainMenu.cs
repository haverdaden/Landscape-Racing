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
    public SaveSystem SaveSystem;

    void Start()
    {     
        if (SaveSystem.SaveExist())
        {
            ContinueButton.SetActive(true);
        }      
    }

    public void StartNewGame()
    {
        SaveSystem.DeleteSave();
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        SceneManager.LoadScene(SaveSystem.Load());
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



}
