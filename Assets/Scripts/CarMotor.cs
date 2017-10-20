using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CarMotor : MonoBehaviour
{

    public float speed = 1500;
    public float rotationSpeed = 1500;
    public float jumpHeight = 500;

    private float movement = 0f;
    private float rotation = 0f;

    public Rigidbody2D carToRotate;
    public Rigidbody2D backWheelRb;
    public Rigidbody2D frontWheelRb;
    public WheelJoint2D backWheel;
    public WheelJoint2D frontWheel;

    private int Ground;



    // Use this for initialization
	void Start ()
	{
	    Ground = LayerMask.GetMask("Ground");

	}
	
	// Update is called once per frame
	void Update ()
	{
	    movement = -Input.GetAxisRaw("Vertical");
	    rotation = -Input.GetAxisRaw("Horizontal");
	}

    void FixedUpdate()
    {
   
        carToRotate.AddTorque(rotation * rotationSpeed * Time.deltaTime);

        //If car breaks stop engine.
        if (backWheel == null || frontWheel == null)
        {
            return;
        }

        JointMotor2D motor = new JointMotor2D
        { motorSpeed = movement * speed * 100 * Time.deltaTime, maxMotorTorque = 10000 };
        backWheel.motor = motor;

        if (Input.GetKeyDown(KeyCode.Space) && (backWheelRb.IsTouchingLayers(Ground) || frontWheelRb.IsTouchingLayers(Ground)))
        {
            carToRotate.AddForce(Vector3.up * jumpHeight + carToRotate.transform.forward,ForceMode2D.Impulse);      
        }

        if (movement == 0f)
        {
            backWheel.useMotor = false;
        }
        else
        {
            backWheel.useMotor = true;
        }
    }
}
