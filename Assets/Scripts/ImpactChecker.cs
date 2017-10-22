using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactChecker : MonoBehaviour
{

    public DeathScript Death;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.magnitude > 80)
        {
            Death.Crash();
        }
    }

}
