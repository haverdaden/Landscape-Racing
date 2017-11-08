using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager TheGameManager = null;


    private void Awake()
    {
        // If Gamemanager is null assign this gameobject as host.
        if (TheGameManager == null)
        {
            TheGameManager = this;
        }
        else if (TheGameManager != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    // Load next level
    public void LoadNextLevel()
    {
        SaveSystem.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Continue(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Quit(int quitToLevel)
    {
        SaveSystem.Save();
        SceneManager.LoadScene(quitToLevel);
    }
}
