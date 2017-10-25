using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public GameObject PauseMenu;
    private bool _paused;
    private float DefaultTimescale;
    private float timeScale = 0;


    void Start()
    {
        DefaultTimescale = Time.timeScale;

    }
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape))
	    {
	        if (!_paused)
	        {
	            PauseMenu.SetActive(true);
	            Time.timeScale = timeScale;
	           // Time.fixedDeltaTime = DefaultTimescale * Time.timeScale;
                _paused = true;
	            return;
	        }
            PauseMenu.SetActive(false);
	        Time.timeScale = DefaultTimescale;
            _paused = false;

	    }
	}

    public void Quit()
    {
        SceneManager.LoadScene(1);
    }
}
