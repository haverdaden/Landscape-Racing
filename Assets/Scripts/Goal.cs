using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public SaveSystem SaveSystem;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "CarBody")
        {
            other.SendMessage("Finished");
            SaveProgress();
            Time.timeScale = 0.1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }

    void SaveProgress()
    {
        SaveSystem.CheckProgress(SceneManager.GetActiveScene().buildIndex);
    }
   
}
