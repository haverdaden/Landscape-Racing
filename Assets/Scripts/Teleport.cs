using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public Transform ObjectToTeleport;
    public Vector3 TeleportPosition;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.name);
        if (collider.gameObject.name == ObjectToTeleport.name)
        {
            collider.transform.position = TeleportPosition;
        }
    }
}////
