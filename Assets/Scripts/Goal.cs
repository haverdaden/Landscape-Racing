using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public PlayerReset PlayerReset;
    public Timer Timer;
    public Text MoneyText;
    public Text MoneyLevelCompletedText;
    public Canvas LevelCompletedCanvas;
    public Button NextLevelButton;
    public static bool LevelCompleted;

    private void Start()
    {
        LevelCompleted = false;

        // CHECK IF THIS IS THE LAST LEVEL
        if ((SceneManager.sceneCountInBuildSettings - 1) <= SceneManager.GetActiveScene().buildIndex)
        {
            Destroy(NextLevelButton.gameObject);
        }

    }

    // check if goal is reached and display level summary.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "CarBody")
        {

            Timer.Finished();
            PlayerReset.SetLevelCompleted();

            MoneyLevelCompletedText.text = "COINS COLLECTED: " + MoneyPickup.GetEarnedLevelMoney();

            if (!PlayerValues.Player.UnlockedLevels.Contains(SceneManager.GetActiveScene().buildIndex))
            {
                PlayerValues.Player.money += 100;
                PlayerValues.Player.UnlockedLevels.Add(SceneManager.GetActiveScene().buildIndex);
                MoneyLevelCompletedText.text = "<color=lime>LEVEL COMPLETED FOR THE FIRST TIME!</color>\n\n <color=yellow>COIN BONUS:</color> <color=orange>100.</color>\n\n   <color=yellow>COINS COLLECTED:</color> <color=orange>" + (MoneyPickup.GetEarnedLevelMoney() + 100 + "</color>");
            }

            LevelCompletedCanvas.enabled = true;
            Destroy(MoneyText);

            Time.timeScale = 0.1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;

            LevelCompleted = true;
            SaveProgress(SceneManager.GetActiveScene().buildIndex);
        }
    }


    // Check if completed level is player progress.
    public static bool CheckProgress(int levelNumber)
    {
        if (levelNumber > PlayerValues.Player.level)
        {
            PlayerValues.Player.UnlockedLevels.Add(levelNumber);
            return true;
        }
        return false;
    }

    //Save the earned money and the completed level if it's progress.
    public static void SaveProgress(int level)
    {
        PlayerValues.Player.money = MoneyPickup.GetTotalMoney();

        if (CheckProgress(level))
        {
            PlayerValues.Player.level = level;
        }

        SaveSystem.Save();
    }


}
