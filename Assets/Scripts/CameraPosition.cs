using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{

    public Transform playerToFollow;
    public int CameraZoomOut = 30;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
       
	    var transformPosition = playerToFollow.transform.position;
	    
        transform.position = new Vector3(transformPosition.x,transformPosition.y,-CameraZoomOut);

      

        //
    }
}
