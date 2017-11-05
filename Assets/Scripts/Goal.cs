using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public ResetCar ResetCar;
    public Timer Timer;
    public Text MoneyText;
    public Text MoneyLevelCompleted;
    public Canvas LevelCompletedCanvas;
    public static bool LevelCompleted;
    public Button NextLevelButton;

    private void Start()
    {
        LevelCompleted = false;

        // CHECK IF THIS IS THE LAST LEVEL
        if (SceneManager.sceneCount <= SceneManager.GetActiveScene().buildIndex)
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
            ResetCar.SetLevelCompleted();

            MoneyLevelCompleted.text = "COINS COLLECTED: " + MoneyPickup.GetEarnedLevelMoney();

            if (!PlayerValues.Player.UnlockedLevels.Contains(SceneManager.GetActiveScene().buildIndex))
            {
                PlayerValues.Player.money += 100;
                PlayerValues.Player.UnlockedLevels.Add(SceneManager.GetActiveScene().buildIndex);
                MoneyLevelCompleted.text = "LEVEL COMPLETED FOR THE FIRST TIME!\n COIN BONUS: 100.\n   COINS COLLECTED: " + (MoneyPickup.GetEarnedLevelMoney() + 100);
            }

            LevelCompletedCanvas.enabled = true;
            Destroy(MoneyText);

            Time.timeScale = 0.1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;

            LevelCompleted = true;
            SaveProgress(SceneManager.GetActiveScene().buildIndex);
        }
    }


    // Load next level
    public void LoadNextLevel()
    {
        SaveSystem.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Check if completed level is player progress.
    public static bool CheckProgress(int levelNumber)
    {
        if (levelNumber > PlayerValues.Player.level)
        {
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
