﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{

    public GameObject gameManager;

	// Use this for initialization
	void Awake () {
	    if (GameManager.TheGameManager == null)
	    {
	        Instantiate(gameManager);
	    }
	}
	

}
