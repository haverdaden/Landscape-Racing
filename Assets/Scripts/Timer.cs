using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    public Text levelCompletedTimerText;
    public HighScoreCheck HighScoreCheck;
    private float StartTime;
    private bool finished;
    private float timePassed;
    private string minutes;
    private string seconds;
    private string timePassedFormatted;

    void Start()
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

	    timePassedFormatted = minutes + ":" + seconds;
	    timerText.text = timePassedFormatted;
	}

    public bool Finished()
    {
        finished = true;

        Destroy(timerText.gameObject);

        timerText = levelCompletedTimerText;
        timerText.color = Color.green;
        timerText.fontSize = 60;
        timerText.text = "Finished in: " + timePassedFormatted;

        if (HighScoreCheck.CheckHighScore(timePassed))
        {
            timerText.text = "NEW HIGHSCORE: " + timePassedFormatted;
            return true;
        }

        return false;
    }
}
