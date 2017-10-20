using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTrapDeath : MonoBehaviour
{
    public DeathScript Death;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "CarBody")
        {
            Death.Crash();
        }
    }






}
