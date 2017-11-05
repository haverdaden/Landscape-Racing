using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsCheck : MonoBehaviour
{

    private Dropdown DropDown;
    // Use this for initialization
    // I FOUND OUT HOW TO LOAD IN LEVELS FROM MY PLAYER DATA HERE: http://answers.unity3d.com/questions/1075609/how-can-i-add-a-new-item-in-dropdown-options.html
    void Start ()
	{
	    DropDown = GetComponent<Dropdown>();

        foreach (var unlockedLevel in PlayerValues.Player.UnlockedLevels) {
	        DropDown.options.Add(new Dropdown.OptionData() { text = "Level: " + unlockedLevel });
        }
        
        // JUST FOR REFRESHING THE DROPDOWN
	    DropDown.value = 1;
	    DropDown.value = 0;

	}




}
