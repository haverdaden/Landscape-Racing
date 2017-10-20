using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public CarMotor Carmotor;
    private bool IsDead;
    private AudioSource Audiosource;

    // Use this for initialization
	void Start ()
	{
	    Audiosource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

	    if (!Carmotor && !IsDead)
	    {
            Audiosource.Play();
	        IsDead = true;
	    }
	}
}
