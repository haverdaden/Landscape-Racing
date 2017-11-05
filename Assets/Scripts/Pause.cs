using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public GameObject PauseMenu;
    private bool _paused;
    private float DefaultTimescale;
    private float DefaultFixedDeltaTime;
    private float timeScale = 0;


    void Start()
    {
        DefaultTimescale = Time.timeScale;
        DefaultFixedDeltaTime = Time.fixedDeltaTime;

    }
	void Update () {

	    if (Input.GetKeyDown(KeyCode.Escape) && !Goal.LevelCompleted)
	    {
	        if (!_paused)
	        {
	            PauseMenu.SetActive(true);
	            Time.timeScale = timeScale;
	            AudioListener.pause = true;
                _paused = true;
	            return;
	        }
            PauseMenu.SetActive(false);
	        Time.timeScale = DefaultTimescale;
	        AudioListener.pause = false;
            _paused = false;

	    }
	}

    public void Quit()
    {
        Time.timeScale = DefaultTimescale;
        Time.fixedDeltaTime = DefaultFixedDeltaTime;
        SaveSystem.Save();
        SceneManager.LoadScene(1);
    }
}
