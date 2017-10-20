using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour {
    public int MovementAmount = 200;
    public float MovementSpeed = 1;
    public Vector3 MoveDirection;
    private bool MoveUp = true;
    private int MoveTicker;


    // Update is called once per frame
    void Update () {

	    if (MoveTicker <= MovementAmount && MoveUp)
	    {
	        transform.position = transform.position + MoveDirection * Time.deltaTime * MovementSpeed;
	        MoveTicker += 1;
	    }
	    else if (MoveTicker >= 0)
	    {
	        MoveUp = false;
	        transform.position = transform.position - MoveDirection * Time.deltaTime * MovementSpeed;
	        MoveTicker -= 1;
	    }
	    else
	    {
	        MoveUp = true;
	    }
    }
}
