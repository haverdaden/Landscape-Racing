using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour {

    public int BuyAmount = 1000;

	// Use this for initialization
	void Start ()
	{
	    var Text = GetComponentInChildren<Text>();
	    Text.text = BuyAmount + " $";
	}




}
