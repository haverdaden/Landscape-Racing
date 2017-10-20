using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    private float Rotation = 0;
    public int RotationSpeed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        

	    transform.eulerAngles = new Vector3(0,0,-Rotation);

	    Rotation += Time.deltaTime * RotationSpeed;


	}
}
