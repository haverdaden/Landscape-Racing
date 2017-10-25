using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteScaler : MonoBehaviour
{

    public float Scaling = 1;
    // Use this for initialization
	void Start ()
	{
        Test();
	}
	
	// Update is called once per frame//
	public void Test ()
	{
        float height = Camera.main.orthographicSize * 2;
	    float width = height * Screen.width / Screen.height; // basically height * screen aspect ratio


	    transform.localScale = Vector3.one * width / Scaling;
    }
}
