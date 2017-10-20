using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject PauseMenu;
    private bool _paused;
    private float DefaultTimescale;
    private float DefaultFixedDeltaTime;
    private float timeScale = 0;
    private float fixedDeltaTime = 0.02f;

    void Start()
    {
        DefaultTimescale = Time.timeScale;
        DefaultFixedDeltaTime = Time.fixedDeltaTime;
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
}
