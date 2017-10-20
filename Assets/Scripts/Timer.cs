using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    public HighScoreCheck HighScoreCheck;
    private float StartTime;
    private bool finished;
    private float timePassed;
    private string minutes;
    private string seconds;

    void Start()
    {
        StartTime = Time.time;
    }

    void OnEnable()
    {
        StartTime = Time.time;
    }
	// Update is called once per frame
	void Update ()
	{

	    if (finished) return;

	    timePassed = Time.time - StartTime;

	    minutes = ((int) timePassed / 60).ToString();
	    seconds = ((int) timePassed % 60).ToString();

	    timerText.text = minutes + ":" + seconds;
	}

    void Finished()
    {
        finished = true;
        timerText.color = Color.green;
        timerText.fontSize = 40;
        timerText.text = "Finished in: " + timerText.text;

        if (HighScoreCheck.CheckHighScore(timePassed))
        {
            timerText.text = "NEW HIGHSCORE: " + minutes + " : " + seconds;
        }
        
    }
}
