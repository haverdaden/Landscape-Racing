using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBirds : MonoBehaviour
{

    public float MovementSpeed = 1;
	// Update is called once per frame
	void Update () {

	    transform.position = transform.position + Vector3.left * Time.deltaTime * MovementSpeed;
    }
}
