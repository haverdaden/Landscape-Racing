using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrownCheck : MonoBehaviour
{
    public Rigidbody2D CarCollider2D;
    public DeathScript Death;
    private int Water;
    private bool inWater;


    //Get Waterlayer and Vehicle gravity on start.
    void Start()
    {
        Water = LayerMask.GetMask("Water");
    }

    //Run every frame
    void Update()
    {
        IsVehicleInWater();
    }

    //Checks if car is in the water and slows the vehicle down.
    private void IsVehicleInWater()
    {
        if (CarCollider2D.IsTouchingLayers(Water) && !inWater)
        {
            inWater = true;
            Death.Freeze();
        }
    }
}

