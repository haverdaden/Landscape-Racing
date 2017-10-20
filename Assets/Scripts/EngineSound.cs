using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour {

    public float topSpeed = 100; // km per hour
    public CarMotor WorkingCarMotor;
    private float currentSpeed = 0;
    private float pitch = 0;
    

    void Update()
    {
        if (Time.timeScale != 0 && WorkingCarMotor)
        {
            currentSpeed = transform.GetComponent<Rigidbody2D>().velocity.magnitude * 3.6f;
            pitch = currentSpeed / topSpeed + 1;

            transform.GetComponent<AudioSource>().pitch = pitch;
        }

    }
}
