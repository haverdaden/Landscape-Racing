using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCrushed : MonoBehaviour
{
    public DeathScript Death;
    public GameObject IgnoreSelf;


    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.name != IgnoreSelf.name && !Collider.isTrigger)
        {         
            Death.Crush();
        }

    }

}
