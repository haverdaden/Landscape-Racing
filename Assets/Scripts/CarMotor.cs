using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CarMotor : MonoBehaviour
{
    public CarUpgrades CarUpgrades;
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
    private float engineMultiplier = 1f;
    private bool fourWheelDriveEnabled;

	void Start ()
    {
        Ground = LayerMask.GetMask("Ground");

        StartSetWheelUpgrade();
        StartSetEngineUpgrade();

    }

    // GET INPUT
    void Update ()
	{
	    movement = -Input.GetAxisRaw("Vertical");
	    rotation = -Input.GetAxisRaw("Horizontal");
	}

    void FixedUpdate()
    {
        // ROTATE CAR
        carToRotate.AddTorque(rotation * rotationSpeed * 1000000 * Time.deltaTime);

        // IF CAR BREAKS -> STOP ENGINE.
        if (backWheel == null || frontWheel == null)
        {
            return;
        }

        // RUN ENGINE ON KEY DOWN
        JointMotor2D motor = new JointMotor2D
        { motorSpeed = movement * speed * engineMultiplier * 100 * Time.deltaTime, maxMotorTorque = 30000 };
        backWheel.motor = motor;

        // CHECK IF FOUR WHEEL DRIVE IS SET
        if (PlayerValues.Player.Drivetrain == 1)
        {
            frontWheel.motor = motor;
            fourWheelDriveEnabled = true;
        }

        Jump();

        if (movement == 0f)
        {
            backWheel.useMotor = false;
            if (!fourWheelDriveEnabled) return;
            frontWheel.useMotor = false;
        }
        else
        {
            backWheel.useMotor = true;
            if (!fourWheelDriveEnabled) return;
            frontWheel.useMotor = true;
        }
    }
    // SET WHEELS FRICTION FROM WHEEL UPGRADES
    private void StartSetWheelUpgrade()
    {

        if (PlayerValues.Player.Wheels > 0)
        {
            PhysicsMaterial2D WheelFriction = backWheelRb.gameObject.GetComponent<Collider2D>().sharedMaterial;
            WheelFriction.friction = WheelFriction.friction * 0.2f + PlayerValues.Player.Wheels;
            print(backWheelRb.gameObject.GetComponent<Collider2D>().sharedMaterial.friction);
        }
    }
    // SET ENGINE BOOST FROM ENGINE UPGRADES
    private void StartSetEngineUpgrade()
    {
        if (PlayerValues.Player.Engine == 0) return;
        engineMultiplier = PlayerValues.Player.Engine * 0.2f + 1f;
    }
    // JUMP WHILE ON GROUND
    private void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && (backWheelRb.IsTouchingLayers(Ground) || frontWheelRb.IsTouchingLayers(Ground)))
        {
            carToRotate.AddForce(Vector3.up * jumpHeight + carToRotate.transform.forward, ForceMode2D.Impulse);
        }
    }
}
