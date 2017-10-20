using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameobject : MonoBehaviour
{

    public GameObject GameObjectToToggle;

    public void ToggleGObject()
    {
        GameObjectToToggle.SetActive(!GameObjectToToggle.activeInHierarchy);
    }
}
