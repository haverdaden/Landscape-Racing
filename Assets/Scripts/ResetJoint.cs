using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetJoint : MonoBehaviour
{

    private Quaternion StartRotation;
    private HingeJoint2D Joint;
    public float Power = 1f;
    public float maxMotorTorque = 10000f;

    // Use this for initialization
    void Start ()
	{
	    StartRotation = transform.rotation;
	    Joint = GetComponent<HingeJoint2D>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (transform.rotation.z < StartRotation.z)
        {
	        JointMotor2D motor = new JointMotor2D
	            { motorSpeed = -Power * 100 * Time.deltaTime, maxMotorTorque = maxMotorTorque };
	        Joint.motor = motor;
	        Joint.useMotor = true;
	    }
        else if (transform.rotation.z > StartRotation.z)
        {

            JointMotor2D motor = new JointMotor2D
                { motorSpeed = Power * 100 * Time.deltaTime, maxMotorTorque = maxMotorTorque };
            Joint.motor = motor;
            Joint.useMotor = true;
        }
	    else
        {
            transform.rotation = StartRotation;
	        Joint.useMotor = false;
	    }

    }
}
